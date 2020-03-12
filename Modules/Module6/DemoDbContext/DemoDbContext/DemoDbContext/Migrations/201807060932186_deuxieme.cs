namespace DemoDbContext.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class deuxieme : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Adresses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nom = c.String(),
                        Numero = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Personnes", "Adresse_Id", c => c.Int());
            CreateIndex("dbo.Personnes", "Adresse_Id");
            AddForeignKey("dbo.Personnes", "Adresse_Id", "dbo.Adresses", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Personnes", "Adresse_Id", "dbo.Adresses");
            DropIndex("dbo.Personnes", new[] { "Adresse_Id" });
            DropColumn("dbo.Personnes", "Adresse_Id");
            DropTable("dbo.Adresses");
        }
    }
}
