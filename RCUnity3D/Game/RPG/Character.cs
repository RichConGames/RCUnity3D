using System.Collections.Generic;

// Copyright © Connor Richards & RichCon Games 2018. All rights reserved.

namespace RCUnity3D.Game.RPG // Unity3D class library for role-playing game characters and setups.
{
    public class Character // An 'RC' role-playing game character. 
    {
        public class RPGComponent // The primary component used for managing an RPG Character using the RCUnity3d library.
        {
            #region Character Attributes

            // Character Details
            public string FirstName { get; private set; }
            public string FamilyName { get; private set; }
            public string Gender { get; set; }
            public string Race { get; set; }
            public string Title { get; set; }

            // Character Background
            public string Discipline { get; private set; }
            List<string> Professions { get; set; }
            List<string> Factions { get; set; }

            // Character Well-Being
            public float Vitality { get; set; }
            public float Vigour { get; set; }
            public float Verve { get; set; }

            // Character Armors
            public float PhysicalArmor { get; set; }
            public float SpecialArmor { get; set; }
            
            // Character Statistics
            public float MaxVitality { get; set; }
            public float MaxVigour { get; set; }
            public float MaxVerve { get; set; }
            public float MaxPArmor { get; set; }
            public float MaxSArmor { get; set; }

            #endregion

            #region RPG Component Constructors

            // Constructs a new RPG Component with optional defaults.
            public RPGComponent(string firstName = "New", string familyName = "Character", string gender = "Default",string race = "Default",string title = "Default", string discipline = "Default", List<string> professions = null, List<string> factions = null, 
                float vitality = 100f, float vigour = 100f, float verve = 100f, float physicalArmor = 100f, float specialArmor = 100f, float maxVitality = 100f, float maxVigour = 100f, float maxVerve = 100f, float maxPArmor = 100f, float maxSArmor = 100f)
            {
                FirstName = firstName;
                FamilyName = familyName;
                Gender = gender;
                Race = race;
                Title = title;

                Discipline = discipline;
                Professions = professions;
                Factions = factions;

                Vitality = vitality;
                Vigour = vigour;
                Verve = verve;

                PhysicalArmor = physicalArmor;
                SpecialArmor = specialArmor;

                MaxVitality = maxVitality;
                MaxVigour = maxVigour;
                MaxVerve = maxVerve;
                MaxPArmor = maxPArmor;
                MaxSArmor = maxSArmor;
            }

            #endregion

            #region Character Roleplaying Game Methods

            // Damages the supplied RPG component's Vitality.
            public void DamageVitality(bool zeroLimit, float damage)
            {
                if (zeroLimit == true)
                {
                    if (Vitality - damage < 0)
                    {
                        Vitality = 0f;
                    }
                    else
                    {
                        Vitality -= damage;
                    }
                }
                else
                {
                    Vitality -= damage;
                }
            }

            // Heals the supplied RPG component's Vitality.
            public void HealVitality(bool maxLimit, float healing)
            {
                if (maxLimit == true)
                {
                    if (Vitality + healing > MaxVitality)
                    {
                        Vitality = MaxVitality;
                    }
                    else
                    {
                        Vitality += healing;
                    }
                }
                else
                {
                    Vitality += healing;
                }
            }

            // Damages the supplied RPG component's physical armor.
            public void DamagePArmor(bool damageVitality, bool zeroLimitVitality, float damage)
            {
                if (damageVitality == true)
                {

                    PhysicalArmor -= damage;

                    if (PhysicalArmor <= 0)
                    {
                        Vitality = Vitality + PhysicalArmor;

                        if (Vitality < 0)
                        {
                            Vitality = 0;
                        }

                        PhysicalArmor = 0;
                    }
                }
                else
                {
                    PhysicalArmor -= damage;

                    if (PhysicalArmor < 0)
                    {
                        PhysicalArmor = 0;
                    }
                }
            }

            // Damages the supplied RPG component's special armor.
            public void DamageSArmor(bool damageVitality, bool zeroLimitVitality, float damage)
            {
                if (damageVitality == true)
                {

                    SpecialArmor -= damage;

                    if (SpecialArmor <= 0)
                    {
                        Vitality = Vitality + SpecialArmor;

                        if (Vitality < 0)
                        {
                            Vitality = 0;
                        }

                        SpecialArmor = 0;
                    }
                }
                else
                {
                    SpecialArmor -= damage;

                    if (SpecialArmor < 0)
                    {
                        SpecialArmor = 0;
                    }
                }
            }

            #endregion
        }

        public class InventoryComponent // An inventory component for role-playing game development using the 'RC' library.
        {
            #region Inventory Attributes

            // Inventory Settings
            public int Size { get; set; }

            // Inventory Contents
            public List<Item> Contents { get; set; }

            // Inventory Currency
            public Dictionary<string, float> Currency { get; set; }

            #endregion

            #region Inventory Component Constructors

            // Constructs a new Inventory Component with optional defaults.
            public InventoryComponent(ref List<Item> contents, ref Dictionary<string, float> currency,int size = 40)
            {
                Size = size;

                Contents = contents;

                Currency = currency;
            }

            #endregion

            #region Inventory Methods

            // Adds a new object to the Inventory Component's contents and returns whether or not it succeeded.
            public bool PickupItem (ref Item item)
            {
                bool pickedUp = false;

                if (item.Interaction == Item.InteractionType.InventoryPickup)
                {
                    if (Contents.Count < Size)
                    {
                        Contents.Add(item);
                        pickedUp = true;
                    }
                    else
                    {
                        pickedUp = false;
                    }
                }

                return pickedUp;
            }

            #endregion
        }

    }
}
