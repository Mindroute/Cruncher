﻿#region Licence
// -----------------------------------------------------------------------
// <copyright file="CruncherCacheSection.cs" company="James South">
//     Copyright (c) 2012,  James South.
//     Dual licensed under the MIT or GPL Version 2 licenses.
// </copyright>
// -----------------------------------------------------------------------
#endregion

namespace Cruncher.Config
{
    #region Using
    using System.Configuration;
    #endregion

    /// <summary>
    /// Represents a CruncherCacheSection within a configuration file.
    /// </summary>
    public class CruncherCacheSection : ConfigurationSection
    {
        #region Properties
        /// <summary>
        /// Gets or sets the maximum number of days to store a css or javascript resource in the cache.
        /// </summary>
        /// <value>The maximum number of days to store a css or javascript resource in the cache.</value>
        /// <remarks>Defaults to 7 if not set. Maximum of 28.</remarks>
        [ConfigurationProperty("maxDays", DefaultValue = "7", IsRequired = false)]
        [IntegerValidator(ExcludeRange = false, MaxValue = 28, MinValue = 0)]
        public int MaxDays
        {
            get
            {
                return (int)this["maxDays"];
            }

            set
            {
                this["maxDays"] = value;
            }
        } 
        #endregion

        #region Methods
        /// <summary>
        /// Retrieves the cache configuration section from the current application configuration. 
        /// </summary>
        /// <returns>The cache configuration section from the current application configuration.</returns>
        public static CruncherCacheSection GetConfiguration()
        {
            CruncherCacheSection clientResourcesCacheSection = ConfigurationManager.GetSection("cruncher/cache") as CruncherCacheSection;

            if (clientResourcesCacheSection != null)
            {
                return clientResourcesCacheSection;
            }

            return new CruncherCacheSection();
        } 
        #endregion
    }
}