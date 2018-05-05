using System;
using System.Linq;
using System.Text;

namespace Hi_Core.Domain.Entities
{
    ///<summary>
    ///
    ///</summary>
    public partial class Hi_Core_Advertise
    {
           public Hi_Core_Advertise(){


           }
           /// <summary>
           /// Desc:
           /// Default:
           /// Nullable:False
           /// </summary>           
           public short Aid {get;set;}

           /// <summary>
           /// Desc:
           /// Default:
           /// Nullable:False
           /// </summary>           
           public string Atitle {get;set;}

           /// <summary>
           /// Desc:
           /// Default:
           /// Nullable:False
           /// </summary>           
           public string Url {get;set;}

           /// <summary>
           /// Desc:
           /// Default:
           /// Nullable:False
           /// </summary>           
           public string Pic1 {get;set;}

    }
}
