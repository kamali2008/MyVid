using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MyVid.Data.Migrations
{
    /// <inheritdoc />
    public partial class v1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Actores",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "varchar(max)", unicode: false, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Actores", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Contenidos",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Titulo = table.Column<string>(type: "varchar(max)", unicode: false, nullable: false),
                    Descripcion = table.Column<string>(type: "varchar(max)", unicode: false, nullable: false),
                    Year = table.Column<int>(type: "int", nullable: false),
                    Duracion = table.Column<int>(type: "int", nullable: true),
                    Director = table.Column<string>(type: "varchar(max)", unicode: false, nullable: false),
                    Tipo = table.Column<string>(type: "varchar(max)", unicode: false, nullable: false),
                    URLVideo = table.Column<string>(type: "varchar(max)", unicode: false, nullable: false),
                    URLPoster = table.Column<string>(type: "varchar(max)", unicode: false, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contenidos", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Generos",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "varchar(max)", unicode: false, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Generos", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Idiomas",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "varchar(max)", unicode: false, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Idiomas", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "varchar(max)", unicode: false, nullable: false),
                    Email = table.Column<string>(type: "varchar(max)", unicode: false, nullable: false),
                    Password = table.Column<string>(type: "varchar(max)", unicode: false, nullable: false),
                    Rol = table.Column<string>(type: "varchar(max)", unicode: false, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "ContenidoActores",
                columns: table => new
                {
                    ContenidoID = table.Column<int>(type: "int", nullable: false),
                    ActorID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContenidoActores", x => new { x.ContenidoID, x.ActorID });
                    table.ForeignKey(
                        name: "FK_ContenidoActores_Actores_ActorID",
                        column: x => x.ActorID,
                        principalTable: "Actores",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ContenidoActores_Contenidos_ContenidoID",
                        column: x => x.ContenidoID,
                        principalTable: "Contenidos",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Peliculas",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ContenidoID = table.Column<int>(type: "int", nullable: false),
                    Calificacion = table.Column<string>(type: "varchar(max)", unicode: false, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Peliculas", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Peliculas_Contenidos_ContenidoID",
                        column: x => x.ContenidoID,
                        principalTable: "Contenidos",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Series",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ContenidoID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Series", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Series_Contenidos_ContenidoID",
                        column: x => x.ContenidoID,
                        principalTable: "Contenidos",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ContenidoGeneros",
                columns: table => new
                {
                    ContenidoID = table.Column<int>(type: "int", nullable: false),
                    GeneroID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContenidoGeneros", x => new { x.ContenidoID, x.GeneroID });
                    table.ForeignKey(
                        name: "FK_ContenidoGeneros_Contenidos_ContenidoID",
                        column: x => x.ContenidoID,
                        principalTable: "Contenidos",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ContenidoGeneros_Generos_GeneroID",
                        column: x => x.GeneroID,
                        principalTable: "Generos",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ContenidoIdiomas",
                columns: table => new
                {
                    ContenidoID = table.Column<int>(type: "int", nullable: false),
                    IdiomaID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContenidoIdiomas", x => new { x.ContenidoID, x.IdiomaID });
                    table.ForeignKey(
                        name: "FK_ContenidoIdiomas_Contenidos_ContenidoID",
                        column: x => x.ContenidoID,
                        principalTable: "Contenidos",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ContenidoIdiomas_Idiomas_IdiomaID",
                        column: x => x.IdiomaID,
                        principalTable: "Idiomas",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Comentarios",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ContenidoID = table.Column<int>(type: "int", nullable: false),
                    UsuarioID = table.Column<int>(type: "int", nullable: false),
                    ContenidoComentario = table.Column<string>(type: "varchar(max)", unicode: false, nullable: false),
                    Fecha = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comentarios", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Comentarios_Contenidos_ContenidoID",
                        column: x => x.ContenidoID,
                        principalTable: "Contenidos",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Comentarios_Usuarios_UsuarioID",
                        column: x => x.UsuarioID,
                        principalTable: "Usuarios",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ListasReproduccion",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "varchar(max)", unicode: false, nullable: false),
                    UsuarioID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ListasReproduccion", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ListasReproduccion_Usuarios_UsuarioID",
                        column: x => x.UsuarioID,
                        principalTable: "Usuarios",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Valoraciones",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ContenidoID = table.Column<int>(type: "int", nullable: false),
                    UsuarioID = table.Column<int>(type: "int", nullable: false),
                    Valor = table.Column<int>(type: "int", nullable: false),
                    Fecha = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Valoraciones", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Valoraciones_Contenidos_ContenidoID",
                        column: x => x.ContenidoID,
                        principalTable: "Contenidos",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Valoraciones_Usuarios_UsuarioID",
                        column: x => x.UsuarioID,
                        principalTable: "Usuarios",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Temporadas",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SerieID = table.Column<int>(type: "int", nullable: false),
                    Número = table.Column<int>(type: "int", nullable: false),
                    Descripcion = table.Column<string>(type: "varchar(max)", unicode: false, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Temporadas", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Temporadas_Series_SerieID",
                        column: x => x.SerieID,
                        principalTable: "Series",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ListaReproduccionContenido",
                columns: table => new
                {
                    ListaReproduccionID = table.Column<int>(type: "int", nullable: false),
                    ContenidoID = table.Column<int>(type: "int", nullable: false),
                    Orden = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ListaReproduccionContenido", x => new { x.ListaReproduccionID, x.ContenidoID });
                    table.ForeignKey(
                        name: "FK_ListaReproduccionContenido_Contenidos_ContenidoID",
                        column: x => x.ContenidoID,
                        principalTable: "Contenidos",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ListaReproduccionContenido_ListasReproduccion_ListaReproduccionID",
                        column: x => x.ListaReproduccionID,
                        principalTable: "ListasReproduccion",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Episodios",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TemporadaID = table.Column<int>(type: "int", nullable: false),
                    Título = table.Column<string>(type: "varchar(max)", unicode: false, nullable: false),
                    Descripcion = table.Column<string>(type: "varchar(max)", unicode: false, nullable: false),
                    Duracion = table.Column<int>(type: "int", nullable: false),
                    RutaArchivo = table.Column<string>(type: "varchar(max)", unicode: false, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Episodios", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Episodios_Temporadas_TemporadaID",
                        column: x => x.TemporadaID,
                        principalTable: "Temporadas",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Comentarios_ContenidoID",
                table: "Comentarios",
                column: "ContenidoID");

            migrationBuilder.CreateIndex(
                name: "IX_Comentarios_UsuarioID",
                table: "Comentarios",
                column: "UsuarioID");

            migrationBuilder.CreateIndex(
                name: "IX_ContenidoActores_ActorID",
                table: "ContenidoActores",
                column: "ActorID");

            migrationBuilder.CreateIndex(
                name: "IX_ContenidoGeneros_GeneroID",
                table: "ContenidoGeneros",
                column: "GeneroID");

            migrationBuilder.CreateIndex(
                name: "IX_ContenidoIdiomas_IdiomaID",
                table: "ContenidoIdiomas",
                column: "IdiomaID");

            migrationBuilder.CreateIndex(
                name: "IX_Episodios_TemporadaID",
                table: "Episodios",
                column: "TemporadaID");

            migrationBuilder.CreateIndex(
                name: "IX_ListaReproduccionContenido_ContenidoID",
                table: "ListaReproduccionContenido",
                column: "ContenidoID");

            migrationBuilder.CreateIndex(
                name: "IX_ListasReproduccion_UsuarioID",
                table: "ListasReproduccion",
                column: "UsuarioID");

            migrationBuilder.CreateIndex(
                name: "IX_Peliculas_ContenidoID",
                table: "Peliculas",
                column: "ContenidoID");

            migrationBuilder.CreateIndex(
                name: "IX_Series_ContenidoID",
                table: "Series",
                column: "ContenidoID");

            migrationBuilder.CreateIndex(
                name: "IX_Temporadas_SerieID",
                table: "Temporadas",
                column: "SerieID");

            migrationBuilder.CreateIndex(
                name: "IX_Valoraciones_ContenidoID",
                table: "Valoraciones",
                column: "ContenidoID");

            migrationBuilder.CreateIndex(
                name: "IX_Valoraciones_UsuarioID",
                table: "Valoraciones",
                column: "UsuarioID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Comentarios");

            migrationBuilder.DropTable(
                name: "ContenidoActores");

            migrationBuilder.DropTable(
                name: "ContenidoGeneros");

            migrationBuilder.DropTable(
                name: "ContenidoIdiomas");

            migrationBuilder.DropTable(
                name: "Episodios");

            migrationBuilder.DropTable(
                name: "ListaReproduccionContenido");

            migrationBuilder.DropTable(
                name: "Peliculas");

            migrationBuilder.DropTable(
                name: "Valoraciones");

            migrationBuilder.DropTable(
                name: "Actores");

            migrationBuilder.DropTable(
                name: "Generos");

            migrationBuilder.DropTable(
                name: "Idiomas");

            migrationBuilder.DropTable(
                name: "Temporadas");

            migrationBuilder.DropTable(
                name: "ListasReproduccion");

            migrationBuilder.DropTable(
                name: "Series");

            migrationBuilder.DropTable(
                name: "Usuarios");

            migrationBuilder.DropTable(
                name: "Contenidos");
        }
    }
}
