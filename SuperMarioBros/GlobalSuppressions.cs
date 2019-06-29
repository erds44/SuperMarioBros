[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1002:DoNotExposeGenericLists", Scope = "member", Target = "SuperMarioBros.Loading.ObjectLoader.#Statics")]
[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1002:DoNotExposeGenericLists", Scope = "member", Target = "SuperMarioBros.Managers.ObjectsManager.#DynamicObjects")]
[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Style", "IDE0059:Value assigned to symbol is never used", Justification = "<Pending>", Scope = "member", Target = "~M:SuperMarioBros.LoadingTest.XMLProcessor.XMLReader(System.String,System.Collections.Generic.List{SuperMarioBros.LoadingTest.ObjectNode})")]
[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA1801:ReviewUnusedParameters", MessageId = "path", Scope = "member", Target = "SuperMarioBros.Loading.ObjectLoader.#LevelLoading(Microsoft.Xna.Framework.Content.ContentManager,System.String)")]
[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA1801:ReviewUnusedParameters", MessageId = "list", Scope = "member", Target = "SuperMarioBros.LoadingTest.XMLProcessor.#XMLReader(System.String,System.Collections.Generic.List`1<SuperMarioBros.LoadingTest.ObjectNode>)")]
[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA1801:ReviewUnusedParameters", MessageId = "content", Scope = "member", Target = "SuperMarioBros.Loading.ObjectLoader.#LevelLoading(Microsoft.Xna.Framework.Content.ContentManager,System.String)")]
[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1030:UseEventsWhereAppropriate", Scope = "member", Target = "SuperMarioBros.Marios.FireBall.#FireExplosion()")]
[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1002:DoNotExposeGenericLists", Scope = "member", Target = "SuperMarioBros.LoadingTest.XMLProcessor.#StaticList()")]
[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1002:DoNotExposeGenericLists", Scope = "member", Target = "SuperMarioBros.Managers.ObjectsManager.#StaticObjects")]
[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1002:DoNotExposeGenericLists", Scope = "member", Target = "SuperMarioBros.Loading.ObjectLoader.#NonCollidables")]
[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1002:DoNotExposeGenericLists", Scope = "member", Target = "SuperMarioBros.LoadingTest.XMLProcessor.#DynamicList()")]
[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1002:DoNotExposeGenericLists", Scope = "member", Target = "SuperMarioBros.Loading.ObjectLoader.#Dynamics")]
[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1026:DefaultParametersShouldNotBeUsed", Scope = "member", Target = "SuperMarioBros.Sprites.ISprite.#Draw(Microsoft.Xna.Framework.Graphics.SpriteBatch,Microsoft.Xna.Framework.Vector2,Microsoft.Xna.Framework.Graphics.SpriteEffects,System.Single)")]
[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1026:DefaultParametersShouldNotBeUsed", Scope = "member", Target = "SuperMarioBros.Loading.ObjectNode.#.ctor(System.String,Microsoft.Xna.Framework.Vector2,System.Int32,System.Int32,System.Int32,System.String,System.Int32)")]
[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1026:DefaultParametersShouldNotBeUsed", Scope = "member", Target = "SuperMarioBros.Physicses.Physics.#.ctor(Microsoft.Xna.Framework.Vector2,System.Single,System.Single,System.Single)")]
[assembly: System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1026:DefaultParametersShouldNotBeUsed", Scope = "member", Target = "SuperMarioBros.Loading.SpritesNode.#.ctor(System.String,System.String,System.Int32,System.Int32,System.Int32,System.Single)")]
/*Error our team supressed
   1. Unused parameters in a method (collison response)
      Since we need to reach a consistancy on Activator Mehtod, we have to leave the direciton parameter unused, i.e. Mario vs item does not care direction
   2. Fire Explosion
      It requires to change the method name or using an event
   3. Generic List
      Code Analysis requires to replace list by collection, but we need list to do sorting, whereas Collection does not have such method
   4. Defualt Parameter Method
      We want to use default parameter methhod such that we do not need to write multiple overload methods
*/

