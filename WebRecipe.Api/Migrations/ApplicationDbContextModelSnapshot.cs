// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using WebRecipe.Api.Data;

#nullable disable

namespace WebRecipe.Api.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.HasSequence("dish_category_hilo")
                .IncrementsBy(10);

            modelBuilder.HasSequence("dish_hilo")
                .IncrementsBy(10);

            modelBuilder.HasSequence("dish_product_hilo")
                .IncrementsBy(10);

            modelBuilder.HasSequence("product_category_hilo")
                .IncrementsBy(10);

            modelBuilder.HasSequence("product_hilo")
                .IncrementsBy(10);

            modelBuilder.HasSequence("user_product_hilo")
                .IncrementsBy(10);

            modelBuilder.Entity("WebRecipe.Api.Data.Entities.DishCategoryEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseHiLo(b.Property<int>("Id"), "dish_category_hilo");

                    b.Property<string>("BlackIcon")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.Property<string>("WhiteIcon")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("DishCategory", (string)null);
                });

            modelBuilder.Entity("WebRecipe.Api.Data.Entities.DishEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseHiLo(b.Property<int>("Id"), "dish_hilo");

                    b.Property<int>("CategoryId")
                        .HasColumnType("integer");

                    b.Property<string>("Difficulty")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.Property<string>("Image")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.Property<string>("Recipe")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.ToTable("Dish", (string)null);
                });

            modelBuilder.Entity("WebRecipe.Api.Data.Entities.DishProductEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseHiLo(b.Property<int>("Id"), "dish_product_hilo");

                    b.Property<double>("Amount")
                        .HasColumnType("double precision");

                    b.Property<int>("DishId")
                        .HasColumnType("integer");

                    b.Property<int>("ProductId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("DishId");

                    b.HasIndex("ProductId");

                    b.ToTable("DishProduct", (string)null);
                });

            modelBuilder.Entity("WebRecipe.Api.Data.Entities.ProductCategoryEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseHiLo(b.Property<int>("Id"), "product_category_hilo");

                    b.Property<string>("BlackIcon")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.Property<string>("WhiteIcon")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("ProductCategory", (string)null);
                });

            modelBuilder.Entity("WebRecipe.Api.Data.Entities.ProductEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseHiLo(b.Property<int>("Id"), "product_hilo");

                    b.Property<string>("Image")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Measure")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.HasKey("Id");

                    b.ToTable("Product", (string)null);
                });

            modelBuilder.Entity("WebRecipe.Api.Data.Entities.UserProductEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseHiLo(b.Property<int>("Id"), "user_product_hilo");

                    b.Property<double>("Amount")
                        .HasColumnType("double precision");

                    b.Property<int>("CategoryId")
                        .HasColumnType("integer");

                    b.Property<string>("Image")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Measure")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.ToTable("UserProduct", (string)null);
                });

            modelBuilder.Entity("WebRecipe.Api.Data.Entities.DishEntity", b =>
                {
                    b.HasOne("WebRecipe.Api.Data.Entities.DishCategoryEntity", "Category")
                        .WithMany()
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");
                });

            modelBuilder.Entity("WebRecipe.Api.Data.Entities.DishProductEntity", b =>
                {
                    b.HasOne("WebRecipe.Api.Data.Entities.DishEntity", "Dish")
                        .WithMany("Products")
                        .HasForeignKey("DishId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WebRecipe.Api.Data.Entities.ProductEntity", "Product")
                        .WithMany("Dishes")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Dish");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("WebRecipe.Api.Data.Entities.UserProductEntity", b =>
                {
                    b.HasOne("WebRecipe.Api.Data.Entities.ProductCategoryEntity", "Category")
                        .WithMany()
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");
                });

            modelBuilder.Entity("WebRecipe.Api.Data.Entities.DishEntity", b =>
                {
                    b.Navigation("Products");
                });

            modelBuilder.Entity("WebRecipe.Api.Data.Entities.ProductEntity", b =>
                {
                    b.Navigation("Dishes");
                });
#pragma warning restore 612, 618
        }
    }
}
