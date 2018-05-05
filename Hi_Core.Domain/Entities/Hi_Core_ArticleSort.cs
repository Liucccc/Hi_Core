using System;
using System.Linq;
using System.Text;

namespace Hi_Core.Domain.Entities
{
    ///<summary>
    ///
    ///</summary>
    public partial class Hi_Core_ArticleSort
    {
           public Hi_Core_ArticleSort(){


           }
           /// <summary>
           /// Desc:
           /// Default:
           /// Nullable:False
           /// </summary>           
           public long Asid {get;set;}

           /// <summary>
           /// Desc:
           /// Default:
           /// Nullable:False
           /// </summary>           
           public string Stitle {get;set;}

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
           public long Layer {get;set;}

           /// <summary>
           /// Desc:
           /// Default:
           /// Nullable:False
           /// </summary>           
           public short Kind {get;set;}

    }
}
