﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FamilyStructure_1.Class
{
    [Serializable]
    public  class ClsPersonalInfo:IEnumerable<ClsPersonalInfo>
    {
        
        public enum GenderType
        {
            Female,
            Male
        }
        public enum RelationlistName
        {
            Person = 0,
            GrandMother =1,
            GrandFather =2,           
            Wife=3,
            Husband=4,
            Father=5,
            Mother=6,
            Brother=7,
            Sister=8,
            Daughter=9,
            Son=10,
            Uncle_FatherBrother=11,
            Aunt_FatherSister=12,
            Uncle_MotherBrother=13,
            Aunt_MotherSister=14,
            MotherInLaw = 15,
            FatherInLaw = 16,

        }
        public bool IsPrimary { get; set; }
        public  List<ClsPersonalInfo> Family = new List<ClsPersonalInfo>();
        public int Id { get; set; }
        public int ParantId { get; set; }
        public virtual string FirstName { get; set; }
        public virtual string LastName { get; set; }
        public virtual DateTime BirthDate { get; set; }
        public virtual string Sorting { get; set; }
        public virtual int RelationIndex { get; set; }
        public virtual RelationlistName RelationName { get; set; }
        public virtual GenderType Gender { get; set; }
        public IEnumerator<ClsPersonalInfo> GetEnumerator()
        {
            return Family.GetEnumerator();
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }

      

   
    }
}
