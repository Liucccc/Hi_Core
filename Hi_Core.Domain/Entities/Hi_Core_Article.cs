using System;
using System.Linq;
using System.Text;

namespace Hi_Core.Domain.Entities
{
    ///<summary>
    ///
    ///</summary>
    public partial class Hi_Core_Article
    {
           public Hi_Core_Article(){


           }
           /// <summary>
           /// Desc:
           /// Default:
           /// Nullable:False
           /// </summary>           
           public long Aid {get;set;}

           /// <summary>
           /// Desc:标题
           /// Default:
           /// Nullable:False
           /// </summary>           
           public string Atitle {get;set;}

           /// <summary>
           /// Desc:链接文件地址
           /// Default:
           /// Nullable:False
           /// </summary>           
           public string Url {get;set;}

           /// <summary>
           /// Desc:
           /// Default:
           /// Nullable:False
           /// </summary>           
           public string Source {get;set;}

           /// <summary>
           /// Desc:
           /// Default:
           /// Nullable:False
           /// </summary>           
           public string Author {get;set;}

           /// <summary>
           /// Desc:有效
           /// Default:
           /// Nullable:False
           /// </summary>           
           public bool Alive {get;set;}

           /// <summary>
           /// Desc:栏目
           /// Default:
           /// Nullable:False
           /// </summary>           
           public short Kind {get;set;}

           /// <summary>
           /// Desc:序号
           /// Default:
           /// Nullable:False
           /// </summary>           
           public long Layer {get;set;}

           /// <summary>
           /// Desc:内容
           /// Default:
           /// Nullable:False
           /// </summary>           
           public string Ainfo {get;set;}

           /// <summary>
           /// Desc:提交日期
           /// Default:
           /// Nullable:False
           /// </summary>           
           public DateTime Atime {get;set;}

           /// <summary>
           /// Desc:图片
           /// Default:
           /// Nullable:False
           /// </summary>           
           public string Pic1 {get;set;}

           /// <summary>
           /// Desc:缩略图
           /// Default:
           /// Nullable:False
           /// </summary>           
           public string Pic2 {get;set;}

           /// <summary>
           /// Desc:概述
           /// Default:
           /// Nullable:False
           /// </summary>           
           public string Summary {get;set;}

           /// <summary>
           /// Desc:
           /// Default:
           /// Nullable:False
           /// </summary>           
           public bool Hot {get;set;}

           /// <summary>
           /// Desc:
           /// Default:
           /// Nullable:False
           /// </summary>           
           public bool Recommend {get;set;}

           /// <summary>
           /// Desc:
           /// Default:
           /// Nullable:False
           /// </summary>           
           public long Asid {get;set;}

           /// <summary>
           /// Desc:副标题
           /// Default:
           /// Nullable:False
           /// </summary>           
           public string ieTitle {get;set;}

           /// <summary>
           /// Desc:关键字
           /// Default:
           /// Nullable:False
           /// </summary>           
           public string seoKeywords {get;set;}

           /// <summary>
           /// Desc:
           /// Default:
           /// Nullable:False
           /// </summary>           
           public string seoDescription {get;set;}

    }
}
