namespace BizStream.AspNetCore.ViewComponentAssets
{
    [AttributeUsage( AttributeTargets.Class )]
    public class ViewComponentScriptAttribute : Attribute
    {
        #region Fields
        private readonly string path;
        #endregion

        #region Properties
        public string Path => path;
        #endregion

        public ViewComponentScriptAttribute( string path )
            => this.path = path;
    }
}