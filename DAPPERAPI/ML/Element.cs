using System;
namespace DAPPERAPI.ML
{
	public class Element
	{
		public Element()
		{
		}
		public int elementID { get; set; } 
		public string elementName { get; set; }
		public DateTime elementDOB { get; set; }
		public int elementUserNum { get; set; }

        public Element(int elementID, string elementName, DateTime elementDOB, int elementUserNum)
        {
            this.elementID = elementID;
            this.elementName = elementName;
            this.elementDOB = elementDOB;
            this.elementUserNum = elementUserNum;
        }
    }
}

