using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WideWorldImporters.BusinessLogic
{
    [Serializable]
    public class StockItem
    {
        private string _StockItemName;
        private string _SupplierName;
        private string _UnitPackage;
        private string _UnitPrice;

        public string StockItemName
        {
            get
            {
                return _StockItemName;
            }
            set
            {
                _StockItemName = value;
            }
        }

        public string SupplierName
        {
            get
            {
                return _SupplierName;
            }
            set
            {
                _SupplierName = value;
            }
        }

        public string UnitPackage
        {
            get
            {
                return _UnitPackage;
            }
            set
            {
                _UnitPackage = value;
            }
        }

        public string UnitPrice
        {
            get
            {
                return _UnitPrice;
            }
            set
            {
                _UnitPrice = value;
            }
        }

        public StockItem(string StockItemName, string SupplierName, string UnitPackage, string UnitPrice)
        {
            _StockItemName = StockItemName;
            _SupplierName = SupplierName;
            _UnitPackage = UnitPackage;
            _UnitPrice = UnitPrice;
        }
    }
}