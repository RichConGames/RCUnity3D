// Copyright © Connor Richards & RichCon Games 2018. All rights reserved.

namespace RCUnity3D // RichCon Unity3D General Purpose Library
{
    public class Release // All release information for this RCUnity3D Library version.
    {

        #region Release Information Attributes

        public float Version { get; private set; }
        public string Date { get; private set; }
        public string LibraryName { get; private set; }
        public string Author { get; private set; }
        public int Year { get; private set; }
        public string Copyright { get; private set; }

        #endregion

        #region Release Information Constructor

        public Release ()
        {
            Version = 0.015f; // The version number for this release.
            Date = "10/02/2018"; // The release date for this release.
            LibraryName = "RichCon Unity3D General Purpose Library"; // The firstName of this .dll library.
            Author = "Connor Richards ( AKA RichCon Games )"; // The author of this library.
            Year = 2018; // The year of this release.
            Copyright = "Copyright © Connor Richards & RichCon Games 2018. All rights reserved."; // The copyright notice for this .dll library.
        }

        #endregion
    }
}
