using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp34
{

        public class Regioneeprovincie
        {
            public string Type { get; set; }
            public geometry geometry { get; set; }
            public Properites properties { get; set; }

        }
        public class Properites
        {
            public int COD_RIP { get; set; }
            public int COD_REG { get; set; }
        public int COD_PROV { get; set; }
        public int COD_CM { get; set; }
        public int COD_UTS { get; set; }
        public string DEN_PROV { get; set; }
        public string DEN_CM { get; set; }
        public string DEN_UTS { get; set; }
        public string SIGLA { get; set; }
        public string TIPO_UTS { get; set; }
        public double SHAPE_AREA { get; set; }
        public double SHAPE_LEN { get; set; }
    }
        public class geometry
        {
            public string type2 { get; set; }
            public float[][][] coordinates { get; set; }

        }
    
}
