using System.Collections.Generic;
using UnityEngine;

// Copyright © Connor Richards & RichCon Games 2018. All rights reserved.

namespace RCUnity3D.Game.RPG // Unity3D class library for role-playing game characters and setups.
{
    public class Object // An 'RC' role-playing game object. 
    {
        #region Object Attributes

        public string Name { get; set; }
        public string ID { get; set; }
        public Texture2D InventoryTexture { get; set; }

        public int IDLength { get; }
        public string IDChars { get; }
        public string IDSeperator { get; }

        #endregion

        #region Functional Elements

        // A randoom number instance
        public System.Random rnd;

        #endregion

        #region Object Constructors

        // Constructs a new object with optional defaults.
        public Object ()
        {
            Name = "Default";
            ID = "Default";
            InventoryTexture = null;

            IDLength = 6;
            IDChars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789_";
            IDSeperator = "-";
        }
        public Object(ref List<Object> objects, ref Texture2D inventoryTexture, string name = "New Object", int idLength = 6, string idChars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789_", string idSeperator = "-")
        {
            Name = name;
            IDLength = idLength;
            IDChars = idChars;
            IDSeperator = idSeperator;
            InventoryTexture = inventoryTexture;

            rnd = new System.Random();

            // Generates a new object ID using the object name appended to a seperator and ID character set. Self-verifies against a list of existing objects.
            bool objectVerified = false;
            int charIndex = 0;
            string generatedID = "";
            while (objectVerified == false)
            {
                generatedID = Name + idSeperator;

                for (int i = 0; i < idLength; i++)
                {
                    charIndex = rnd.Next(idChars.Length);
                    generatedID = generatedID + idChars[charIndex];
                }

                objectVerified = true;

                if (objects != null)
                {
                    foreach (Object obj in objects)
                    {
                        if (obj.ID == generatedID)
                        {
                            objectVerified = false;
                            break;
                        }
                    }
                }

                if (objectVerified == true)
                {
                    ID = generatedID;
                }
            }
        }

        #endregion

        #region Object Methods

        // Checks to see if an object with this ID already exists. Returns true or false.
        public bool ObjectExists (List<Object> objects)
        {
            bool objectExists = false;

            foreach (Object obj in objects)
            {
                if (obj.ID == ID)
                {
                    objectExists = true;
                    break;
                }
            }

            return objectExists;
        }

        #endregion


    }

    public class Item : Object 
    {
        #region Item Attributes

        // An enumeration for object interaction type.
        public enum InteractionType { DialogLauncher, InventoryPickup, WorldInteractive }
        public  InteractionType Interaction { get; set; }

        #endregion

        #region Item Constructors

        // Constructs a new item (inherits from Object) with optional defaults.
        public Item(ref List<Object> objects, ref Texture2D inventoryTexture, InteractionType interaction = InteractionType.DialogLauncher) : base()
        {
            Interaction = interaction;

            // Generates a new item ID 
            if (ID == "Default" || ID == null)
            {
                // Generates a new object ID using the object name appended to a seperator and ID character set. Self-verifies against a list of existing objects.
                bool objectVerified = false;
                int charIndex = 0;
                string generatedID = "";
                while (objectVerified == false)
                {
                    generatedID = Name + IDSeperator;

                    for (int i = 0; i < IDLength; i++)
                    {
                        charIndex = rnd.Next(IDChars.Length);
                        generatedID = generatedID + IDChars[charIndex];
                    }

                    objectVerified = true;

                    if (objects != null)
                    {
                        foreach (Object obj in objects)
                        {
                            if (obj.ID == generatedID)
                            {
                                objectVerified = false;
                                break;
                            }
                        }
                    }

                    if (objectVerified == true)
                    {
                        ID = generatedID;
                    }
                }
            }
        }

        #endregion

        #region Item Methods



        #endregion
    } // An 'RC' role-playing game interactive item. (Inherits from 'Object' class.)
}
