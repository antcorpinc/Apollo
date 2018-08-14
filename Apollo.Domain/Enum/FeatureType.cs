using System;
using System.Collections.Generic;
using System.Text;

namespace Apollo.Domain.Enum
{
    public static class FeatureTypes
    {

        // Apollo Features from 1 - 1000
        public enum ApolloFeature
        {
            // Top Level Menu Features for Apollo  Assign 1 - 10 For top level Menus
            ApolloDashboard = 1,
            SocietyManagement,
            FormManagement,
            UserManagement,
            Advertisements,
            Reports,

            // Each child level menus will have abucket of 10 items

            // Child Level Menu Features  for Apollo Dashboard Assign 11 - 20

            // Child Level Menu Features  for Society Management  Assign 21 - 30
            SocietyProfile = 21,            

            // Child Level Menu Features  for FormsManagement  Assign 31 - 40
            FormDashboard= 31,
            Forms,

            // Child Level Menu Features  for UserManagement  Assign 41 - 50
            

            // Child Level Menu Features  for UserManagement  Assign 51 - 60
            //LocalAdv = 51,
            //CityAdv,
            //StateAdv,
            //CountryAdv
            Advs = 51

            // Try to Add Reports to last since there could be many that could be added
            // Child Level Menu Features  for Reports Assign 61 - 70


            // Todo: Add others

            // Each Grand Child will have a bucket of 10(5?) items

        }

        // BackOffice Features from 1001 - 2000
        public enum BackOfficeFeature
        {
            // Top Level Menu Features For BackOffice - Assign 1001 - 1015 For top level Menus
            BackOfficeDashboard = 1001,
            SocietyManagement,
            FinanceManagement,
            UserManagement,
            Reports,

            // Todo Add Child Level Menus

            // Each Child Level Menus will have a bucket of 10 items

            // Child Level Menu Features  for Apollo Dashboard Assign 1011 - 1020

            // Child Level Menus For SocietyManagement -- 1021 - 1030
            SocietyProfile = 1021,

            // Child Level menus for FinanceManagement -- 1031 - 1040

            // Child Level menus for UserManagement -- 1041 - 1050
            SupportUser = 1041,
            SocietyUser,
            RolesPermissions
                
            // Child Level Menus For Reports -- Add more for this may be 20 ??
            // 1051 - 1070


            // Each Grand Child will have a bucket of 10(5?) items
            // Or do we give a fixed number for ???Each child will have fixed 50 for the grandchild Item
            // Ex GrandChild of BackOfficeDashboard 1111 --->1160
            // GrandChild of BackOfficeDashboard 1111 --->1160
            // GrandChild of AgencyManagement 1161 --->1210
            // GrandChild of FinanceManagement 1211 --->1260
            // GrandChild of BackOfficeDashboard 1261 --->1310
            // GrandChild of ReservationManagement 1311 --->1360
            // GrandChild of SupplierManagement 1361 --->1410
            // GrandChild of UserManagement 1411 --->1460
            // GrandChild of ToolsManagement 1461 --->1510
            // GrandChild of ReportsManagement 1511 --->1560



        }
    }

}
