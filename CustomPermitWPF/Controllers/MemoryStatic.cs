using System;
using System.Collections.Generic;

using CustomPermitWPF.Domain;

namespace CustomPermitWPF.Controllers
{
    
    public static class MemoryStatic
    {
        public static int docID = 1;
        public static int permID = 1;
        public static int ministryID = 1;

        public static List<Ministry> MinistrieList = new List<Ministry>(); 
        public static List<Permission> PermissionList = new List<Permission>();
        public static List<Documents> DocumentList = new List<Documents>();
        
        public static void AddMinistry(Ministry o)
        {
            o.ID = ministryID;
            if(!MinistrieList.Contains(o))  MinistrieList.Add(o);
            ministryID++;

        }
        public static void AddPerm(Permission p)
        {
            p.ID = permID;
            p.passed = false;
            if(!PermissionList.Contains(p))  PermissionList.Add(p);
            permID++;

        }
        public static void AddDoc(Documents d)
        {
            d.ID = docID;
            if(!DocumentList.Contains(d))  DocumentList.Add(d);
            docID++;

        }



    }
}