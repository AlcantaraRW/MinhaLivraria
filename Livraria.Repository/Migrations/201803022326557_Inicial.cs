namespace Livraria.Repository.Migrations
{
    using System.Data.Entity.Migrations;

    public partial class Inicial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Livros",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Isbn = c.Long(nullable: false),
                        Titulo = c.String(nullable: false, maxLength: 255),
                        Autor = c.String(nullable: false, maxLength: 255),
                        AnoPublicacao = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Livros");
        }
    }
}
