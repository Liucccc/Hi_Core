using System;
using System.Linq;
using System.Text;

namespace Hi_Core.Domain.Entities
{
    ///<summary>
    ///
    ///</summary>
    public partial class Hi_Core_adminUsersLevel
    {
           public Hi_Core_adminUsersLevel(){


           }
           /// <summary>
           /// Desc:
           /// Default:
           /// Nullable:False
           /// </summary>           
           public long Aulid {get;set;}

           /// <summary>
           /// Desc:
           /// Default:
           /// Nullable:False
           /// </summary>           
           public string Ltitle {get;set;}

           /// <summary>
           /// Desc:
           /// Default:
           /// Nullable:False
           /// </summary>           
           public bool Alive {get;set;}

           /// <summary>
           /// Desc:
           /// Default:
           /// Nullable:False
           /// </summary>           
           public string Area {get;set;}

    }
}
