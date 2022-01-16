﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ORM_Framework_DP
{
    class And : LogicalComparison
    {
        public And()
        {
            conditions = new List<Condition>();
        }

        public And(Condition a, Condition b)
        {
            conditions = new List<Condition>();
            conditions.Add(a);
            conditions.Add(b);
        }
        public And(List<Condition> conditions)
        {
            this.conditions = conditions;
        }
        public override string getLogic()
        {
            return "AND";
        }
    }
}