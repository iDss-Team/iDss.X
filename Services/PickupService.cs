
using Microsoft.EntityFrameworkCore;
using iDss.X.Data;
using iDss.X.Models;
using BootstrapBlazor.Components;
using Microsoft.EntityFrameworkCore.Metadata;
using System.Diagnostics.CodeAnalysis;
using System.Collections.Concurrent;

namespace iDss.X.Services
{
    public class PickupService
    {
        private readonly AppDbContext _db;

        public PickupService(AppDbContext context)
        {
            _db = context;
        }

        public IEnumerable<int> PageItemsSource => new int[] { 10, 20, 40 };

        #region "Entry Data Pickup"
        #endregion

        #region "Control Status Pickup"
        #endregion

        #region "Monitoring Pickup"
        #endregion
    }
}
