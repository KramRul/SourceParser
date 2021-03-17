using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SourceParser.DataAccessLevel.Migrations
{
    public partial class Remove69Param : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Authors",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Surname = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Patronymic = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Authors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Co_Authors",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Co_Authors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Date",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Date", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DatePublisher",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DatePublisher", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DateUniver",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DateUniver", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Editors",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Editors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Group",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Group", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GroupPublisher",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GroupPublisher", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GroupUniver",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GroupUniver", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ImportLinksData",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    SKU = table.Column<Guid>(nullable: false),
                    SourceLink = table.Column<string>(nullable: true),
                    BiblLinkClass = table.Column<string>(nullable: true),
                    SearchParameter0 = table.Column<string>(nullable: true),
                    SearchParameter1 = table.Column<string>(nullable: true),
                    SearchParameter2 = table.Column<string>(nullable: true),
                    SearchParameter3 = table.Column<string>(nullable: true),
                    SearchParameter4 = table.Column<string>(nullable: true),
                    SearchParameter5 = table.Column<string>(nullable: true),
                    SearchParameter6 = table.Column<string>(nullable: true),
                    SearchParameter7 = table.Column<string>(nullable: true),
                    SearchParameter8 = table.Column<string>(nullable: true),
                    SearchParameter9 = table.Column<string>(nullable: true),
                    SearchParameter10 = table.Column<string>(nullable: true),
                    SearchParameter11 = table.Column<string>(nullable: true),
                    SearchParameter12 = table.Column<string>(nullable: true),
                    SearchParameter13 = table.Column<string>(nullable: true),
                    SearchParameter14 = table.Column<string>(nullable: true),
                    SearchParameter15 = table.Column<string>(nullable: true),
                    SearchParameter16 = table.Column<string>(nullable: true),
                    SearchParameter17 = table.Column<string>(nullable: true),
                    SearchParameter18 = table.Column<string>(nullable: true),
                    SearchParameter19 = table.Column<string>(nullable: true),
                    SearchParameter20 = table.Column<string>(nullable: true),
                    SearchParameter21 = table.Column<string>(nullable: true),
                    SearchParameter22 = table.Column<string>(nullable: true),
                    SearchParameter23 = table.Column<string>(nullable: true),
                    SearchParameter24 = table.Column<string>(nullable: true),
                    SearchParameter25 = table.Column<string>(nullable: true),
                    SearchParameter26 = table.Column<string>(nullable: true),
                    SearchParameter27 = table.Column<string>(nullable: true),
                    SearchParameter28 = table.Column<string>(nullable: true),
                    SearchParameter29 = table.Column<string>(nullable: true),
                    SearchParameter30 = table.Column<string>(nullable: true),
                    SearchParameter31 = table.Column<string>(nullable: true),
                    SearchParameter32 = table.Column<string>(nullable: true),
                    SearchParameter33 = table.Column<string>(nullable: true),
                    SearchParameter34 = table.Column<string>(nullable: true),
                    SearchParameter35 = table.Column<string>(nullable: true),
                    SearchParameter36 = table.Column<string>(nullable: true),
                    SearchParameter37 = table.Column<string>(nullable: true),
                    SearchParameter38 = table.Column<string>(nullable: true),
                    SearchParameter39 = table.Column<string>(nullable: true),
                    SearchParameter40 = table.Column<string>(nullable: true),
                    SearchParameter41 = table.Column<string>(nullable: true),
                    SearchParameter42 = table.Column<string>(nullable: true),
                    SearchParameter43 = table.Column<string>(nullable: true),
                    SearchParameter44 = table.Column<string>(nullable: true),
                    SearchParameter45 = table.Column<string>(nullable: true),
                    SearchParameter46 = table.Column<string>(nullable: true),
                    SearchParameter47 = table.Column<string>(nullable: true),
                    SearchParameter48 = table.Column<string>(nullable: true),
                    SearchParameter49 = table.Column<string>(nullable: true),
                    SearchParameter50 = table.Column<string>(nullable: true),
                    SearchParameter51 = table.Column<string>(nullable: true),
                    SearchParameter52 = table.Column<string>(nullable: true),
                    SearchParameter53 = table.Column<string>(nullable: true),
                    SearchParameter54 = table.Column<string>(nullable: true),
                    SearchParameter55 = table.Column<string>(nullable: true),
                    SearchParameter56 = table.Column<string>(nullable: true),
                    SearchParameter57 = table.Column<string>(nullable: true),
                    SearchParameter58 = table.Column<string>(nullable: true),
                    SearchParameter59 = table.Column<string>(nullable: true),
                    SearchParameter60 = table.Column<string>(nullable: true),
                    SearchParameter61 = table.Column<string>(nullable: true),
                    SearchParameter62 = table.Column<string>(nullable: true),
                    SearchParameter63 = table.Column<string>(nullable: true),
                    SearchParameter64 = table.Column<string>(nullable: true),
                    SearchParameter65 = table.Column<string>(nullable: true),
                    SearchParameter66 = table.Column<string>(nullable: true),
                    SearchParameter67 = table.Column<string>(nullable: true),
                    SearchParameter68 = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ImportLinksData", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Label",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Form = table.Column<string>(nullable: true),
                    Prefix = table.Column<string>(nullable: true),
                    Suffix = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Label", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Name",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    InitializeWith = table.Column<string>(nullable: true),
                    Delimiter = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Name", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Page",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    CountOfPages = table.Column<string>(nullable: true),
                    PageFirst = table.Column<string>(nullable: true),
                    PageLast = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Page", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Publishers",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Address = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Publishers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Translator",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Translator", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DatePart",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    DateId = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DatePart", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DatePart_Date_DateId",
                        column: x => x.DateId,
                        principalTable: "Date",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "YearDate",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    DateId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_YearDate", x => x.Id);
                    table.ForeignKey(
                        name: "FK_YearDate_Date_DateId",
                        column: x => x.DateId,
                        principalTable: "Date",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DatePartPublisher",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    DatePublisherId = table.Column<string>(nullable: true),
                    NamePublisher = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DatePartPublisher", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DatePartPublisher_DatePublisher_DatePublisherId",
                        column: x => x.DatePublisherId,
                        principalTable: "DatePublisher",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "YearDatePublisher",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    DatePublisherId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_YearDatePublisher", x => x.Id);
                    table.ForeignKey(
                        name: "FK_YearDatePublisher_DatePublisher_DatePublisherId",
                        column: x => x.DatePublisherId,
                        principalTable: "DatePublisher",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DatePartUniver",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    DateUniverId = table.Column<string>(nullable: true),
                    NameUniver = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DatePartUniver", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DatePartUniver_DateUniver_DateUniverId",
                        column: x => x.DateUniverId,
                        principalTable: "DateUniver",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "YearDateUniver",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    DateUniverId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_YearDateUniver", x => x.Id);
                    table.ForeignKey(
                        name: "FK_YearDateUniver_DateUniver_DateUniverId",
                        column: x => x.DateUniverId,
                        principalTable: "DateUniver",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Texts",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    GroupId = table.Column<string>(nullable: true),
                    Value = table.Column<string>(nullable: true),
                    Suffix = table.Column<string>(nullable: true),
                    Prefix = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Texts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Texts_Group_GroupId",
                        column: x => x.GroupId,
                        principalTable: "Group",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Webdoc",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    GroupId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Webdoc", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Webdoc_Group_GroupId",
                        column: x => x.GroupId,
                        principalTable: "Group",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TextPublisher",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    GroupPublisherId = table.Column<string>(nullable: true),
                    Value = table.Column<string>(nullable: true),
                    Suffix = table.Column<string>(nullable: true),
                    Prefix = table.Column<string>(nullable: true),
                    Variable = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TextPublisher", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TextPublisher_GroupPublisher_GroupPublisherId",
                        column: x => x.GroupPublisherId,
                        principalTable: "GroupPublisher",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TextUniver",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    GroupUniverId = table.Column<string>(nullable: true),
                    Value = table.Column<string>(nullable: true),
                    Suffix = table.Column<string>(nullable: true),
                    Prefix = table.Column<string>(nullable: true),
                    Variable = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TextUniver", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TextUniver_GroupUniver_GroupUniverId",
                        column: x => x.GroupUniverId,
                        principalTable: "GroupUniver",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AuthorFirst",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    LabelId = table.Column<string>(nullable: true),
                    NameId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AuthorFirst", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AuthorFirst_Label_LabelId",
                        column: x => x.LabelId,
                        principalTable: "Label",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AuthorFirst_Name_NameId",
                        column: x => x.NameId,
                        principalTable: "Name",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AuthorSecond",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    LabelId = table.Column<string>(nullable: true),
                    NameId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AuthorSecond", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AuthorSecond_Label_LabelId",
                        column: x => x.LabelId,
                        principalTable: "Label",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AuthorSecond_Name_NameId",
                        column: x => x.NameId,
                        principalTable: "Name",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Documents",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Type = table.Column<int>(nullable: false),
                    AuthorId = table.Column<string>(nullable: true),
                    Co_AuthorId = table.Column<string>(nullable: true),
                    EditorId = table.Column<string>(nullable: true),
                    PublisherId = table.Column<string>(nullable: true),
                    TranslatorId = table.Column<string>(nullable: true),
                    Title = table.Column<string>(nullable: true),
                    TitleOfConference = table.Column<string>(nullable: true),
                    Date = table.Column<DateTime>(nullable: false),
                    Edition = table.Column<string>(nullable: true),
                    URLAdress = table.Column<string>(nullable: true),
                    Language = table.Column<string>(nullable: true),
                    PageId = table.Column<string>(nullable: true),
                    Volume = table.Column<string>(nullable: true),
                    AdditionalInf = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Documents", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Documents_Authors_AuthorId",
                        column: x => x.AuthorId,
                        principalTable: "Authors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Documents_Co_Authors_Co_AuthorId",
                        column: x => x.Co_AuthorId,
                        principalTable: "Co_Authors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Documents_Editors_EditorId",
                        column: x => x.EditorId,
                        principalTable: "Editors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Documents_Page_PageId",
                        column: x => x.PageId,
                        principalTable: "Page",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Documents_Publishers_PublisherId",
                        column: x => x.PublisherId,
                        principalTable: "Publishers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Documents_Translator_TranslatorId",
                        column: x => x.TranslatorId,
                        principalTable: "Translator",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Publisher",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    GroupPublisherId = table.Column<string>(nullable: true),
                    YearDatePublisherId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Publisher", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Publisher_GroupPublisher_GroupPublisherId",
                        column: x => x.GroupPublisherId,
                        principalTable: "GroupPublisher",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Publisher_YearDatePublisher_YearDatePublisherId",
                        column: x => x.YearDatePublisherId,
                        principalTable: "YearDatePublisher",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PublishUniver",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    GroupUniverId = table.Column<string>(nullable: true),
                    YearDateUniverId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PublishUniver", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PublishUniver_GroupUniver_GroupUniverId",
                        column: x => x.GroupUniverId,
                        principalTable: "GroupUniver",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PublishUniver_YearDateUniver_YearDateUniverId",
                        column: x => x.YearDateUniverId,
                        principalTable: "YearDateUniver",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PagesNumber",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    TextId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PagesNumber", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PagesNumber_Texts_TextId",
                        column: x => x.TextId,
                        principalTable: "Texts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PagesRange",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    TextId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PagesRange", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PagesRange_Texts_TextId",
                        column: x => x.TextId,
                        principalTable: "Texts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PublishVolume",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    TextId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PublishVolume", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PublishVolume_Texts_TextId",
                        column: x => x.TextId,
                        principalTable: "Texts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Title",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Value = table.Column<string>(nullable: true),
                    TextId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Title", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Title_Texts_TextId",
                        column: x => x.TextId,
                        principalTable: "Texts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TitleOfConference",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    TextId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TitleOfConference", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TitleOfConference_Texts_TextId",
                        column: x => x.TextId,
                        principalTable: "Texts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Notes",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Value = table.Column<string>(nullable: true),
                    DocumentId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Notes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Notes_Documents_DocumentId",
                        column: x => x.DocumentId,
                        principalTable: "Documents",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Styles",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    EtAl = table.Column<string>(nullable: true),
                    EtAlMax = table.Column<int>(nullable: false),
                    PageRangeDelimiter = table.Column<string>(nullable: true),
                    TitleId = table.Column<string>(nullable: true),
                    AuthorFirstId = table.Column<string>(nullable: true),
                    AuthorSecondId = table.Column<string>(nullable: true),
                    WebdocId = table.Column<string>(nullable: true),
                    PublisherId = table.Column<string>(nullable: true),
                    PublishuniverId = table.Column<string>(nullable: true),
                    YearDateStyleId = table.Column<string>(nullable: true),
                    PublishVolumeId = table.Column<string>(nullable: true),
                    PagesNumberId = table.Column<string>(nullable: true),
                    PagesRangeId = table.Column<string>(nullable: true),
                    TitleOfConferenceId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Styles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Styles_AuthorFirst_AuthorFirstId",
                        column: x => x.AuthorFirstId,
                        principalTable: "AuthorFirst",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Styles_AuthorSecond_AuthorSecondId",
                        column: x => x.AuthorSecondId,
                        principalTable: "AuthorSecond",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Styles_PagesNumber_PagesNumberId",
                        column: x => x.PagesNumberId,
                        principalTable: "PagesNumber",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Styles_PagesRange_PagesRangeId",
                        column: x => x.PagesRangeId,
                        principalTable: "PagesRange",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Styles_PublishVolume_PublishVolumeId",
                        column: x => x.PublishVolumeId,
                        principalTable: "PublishVolume",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Styles_Publisher_PublisherId",
                        column: x => x.PublisherId,
                        principalTable: "Publisher",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Styles_PublishUniver_PublishuniverId",
                        column: x => x.PublishuniverId,
                        principalTable: "PublishUniver",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Styles_Title_TitleId",
                        column: x => x.TitleId,
                        principalTable: "Title",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Styles_TitleOfConference_TitleOfConferenceId",
                        column: x => x.TitleOfConferenceId,
                        principalTable: "TitleOfConference",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Styles_Webdoc_WebdocId",
                        column: x => x.WebdocId,
                        principalTable: "Webdoc",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Styles_YearDate_YearDateStyleId",
                        column: x => x.YearDateStyleId,
                        principalTable: "YearDate",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "References",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Value = table.Column<string>(nullable: true),
                    DocumentId = table.Column<string>(nullable: true),
                    StyleId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_References", x => x.Id);
                    table.ForeignKey(
                        name: "FK_References_Documents_DocumentId",
                        column: x => x.DocumentId,
                        principalTable: "Documents",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_References_Styles_StyleId",
                        column: x => x.StyleId,
                        principalTable: "Styles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AuthorFirst_LabelId",
                table: "AuthorFirst",
                column: "LabelId");

            migrationBuilder.CreateIndex(
                name: "IX_AuthorFirst_NameId",
                table: "AuthorFirst",
                column: "NameId");

            migrationBuilder.CreateIndex(
                name: "IX_AuthorSecond_LabelId",
                table: "AuthorSecond",
                column: "LabelId");

            migrationBuilder.CreateIndex(
                name: "IX_AuthorSecond_NameId",
                table: "AuthorSecond",
                column: "NameId");

            migrationBuilder.CreateIndex(
                name: "IX_DatePart_DateId",
                table: "DatePart",
                column: "DateId");

            migrationBuilder.CreateIndex(
                name: "IX_DatePartPublisher_DatePublisherId",
                table: "DatePartPublisher",
                column: "DatePublisherId");

            migrationBuilder.CreateIndex(
                name: "IX_DatePartUniver_DateUniverId",
                table: "DatePartUniver",
                column: "DateUniverId");

            migrationBuilder.CreateIndex(
                name: "IX_Documents_AuthorId",
                table: "Documents",
                column: "AuthorId");

            migrationBuilder.CreateIndex(
                name: "IX_Documents_Co_AuthorId",
                table: "Documents",
                column: "Co_AuthorId");

            migrationBuilder.CreateIndex(
                name: "IX_Documents_EditorId",
                table: "Documents",
                column: "EditorId");

            migrationBuilder.CreateIndex(
                name: "IX_Documents_PageId",
                table: "Documents",
                column: "PageId");

            migrationBuilder.CreateIndex(
                name: "IX_Documents_PublisherId",
                table: "Documents",
                column: "PublisherId");

            migrationBuilder.CreateIndex(
                name: "IX_Documents_TranslatorId",
                table: "Documents",
                column: "TranslatorId");

            migrationBuilder.CreateIndex(
                name: "IX_Notes_DocumentId",
                table: "Notes",
                column: "DocumentId");

            migrationBuilder.CreateIndex(
                name: "IX_PagesNumber_TextId",
                table: "PagesNumber",
                column: "TextId");

            migrationBuilder.CreateIndex(
                name: "IX_PagesRange_TextId",
                table: "PagesRange",
                column: "TextId");

            migrationBuilder.CreateIndex(
                name: "IX_Publisher_GroupPublisherId",
                table: "Publisher",
                column: "GroupPublisherId");

            migrationBuilder.CreateIndex(
                name: "IX_Publisher_YearDatePublisherId",
                table: "Publisher",
                column: "YearDatePublisherId");

            migrationBuilder.CreateIndex(
                name: "IX_PublishUniver_GroupUniverId",
                table: "PublishUniver",
                column: "GroupUniverId");

            migrationBuilder.CreateIndex(
                name: "IX_PublishUniver_YearDateUniverId",
                table: "PublishUniver",
                column: "YearDateUniverId");

            migrationBuilder.CreateIndex(
                name: "IX_PublishVolume_TextId",
                table: "PublishVolume",
                column: "TextId");

            migrationBuilder.CreateIndex(
                name: "IX_References_DocumentId",
                table: "References",
                column: "DocumentId");

            migrationBuilder.CreateIndex(
                name: "IX_References_StyleId",
                table: "References",
                column: "StyleId");

            migrationBuilder.CreateIndex(
                name: "IX_Styles_AuthorFirstId",
                table: "Styles",
                column: "AuthorFirstId");

            migrationBuilder.CreateIndex(
                name: "IX_Styles_AuthorSecondId",
                table: "Styles",
                column: "AuthorSecondId");

            migrationBuilder.CreateIndex(
                name: "IX_Styles_PagesNumberId",
                table: "Styles",
                column: "PagesNumberId");

            migrationBuilder.CreateIndex(
                name: "IX_Styles_PagesRangeId",
                table: "Styles",
                column: "PagesRangeId");

            migrationBuilder.CreateIndex(
                name: "IX_Styles_PublishVolumeId",
                table: "Styles",
                column: "PublishVolumeId");

            migrationBuilder.CreateIndex(
                name: "IX_Styles_PublisherId",
                table: "Styles",
                column: "PublisherId");

            migrationBuilder.CreateIndex(
                name: "IX_Styles_PublishuniverId",
                table: "Styles",
                column: "PublishuniverId");

            migrationBuilder.CreateIndex(
                name: "IX_Styles_TitleId",
                table: "Styles",
                column: "TitleId");

            migrationBuilder.CreateIndex(
                name: "IX_Styles_TitleOfConferenceId",
                table: "Styles",
                column: "TitleOfConferenceId");

            migrationBuilder.CreateIndex(
                name: "IX_Styles_WebdocId",
                table: "Styles",
                column: "WebdocId");

            migrationBuilder.CreateIndex(
                name: "IX_Styles_YearDateStyleId",
                table: "Styles",
                column: "YearDateStyleId");

            migrationBuilder.CreateIndex(
                name: "IX_TextPublisher_GroupPublisherId",
                table: "TextPublisher",
                column: "GroupPublisherId");

            migrationBuilder.CreateIndex(
                name: "IX_Texts_GroupId",
                table: "Texts",
                column: "GroupId");

            migrationBuilder.CreateIndex(
                name: "IX_TextUniver_GroupUniverId",
                table: "TextUniver",
                column: "GroupUniverId");

            migrationBuilder.CreateIndex(
                name: "IX_Title_TextId",
                table: "Title",
                column: "TextId");

            migrationBuilder.CreateIndex(
                name: "IX_TitleOfConference_TextId",
                table: "TitleOfConference",
                column: "TextId");

            migrationBuilder.CreateIndex(
                name: "IX_Webdoc_GroupId",
                table: "Webdoc",
                column: "GroupId");

            migrationBuilder.CreateIndex(
                name: "IX_YearDate_DateId",
                table: "YearDate",
                column: "DateId");

            migrationBuilder.CreateIndex(
                name: "IX_YearDatePublisher_DatePublisherId",
                table: "YearDatePublisher",
                column: "DatePublisherId");

            migrationBuilder.CreateIndex(
                name: "IX_YearDateUniver_DateUniverId",
                table: "YearDateUniver",
                column: "DateUniverId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DatePart");

            migrationBuilder.DropTable(
                name: "DatePartPublisher");

            migrationBuilder.DropTable(
                name: "DatePartUniver");

            migrationBuilder.DropTable(
                name: "ImportLinksData");

            migrationBuilder.DropTable(
                name: "Notes");

            migrationBuilder.DropTable(
                name: "References");

            migrationBuilder.DropTable(
                name: "TextPublisher");

            migrationBuilder.DropTable(
                name: "TextUniver");

            migrationBuilder.DropTable(
                name: "Documents");

            migrationBuilder.DropTable(
                name: "Styles");

            migrationBuilder.DropTable(
                name: "Authors");

            migrationBuilder.DropTable(
                name: "Co_Authors");

            migrationBuilder.DropTable(
                name: "Editors");

            migrationBuilder.DropTable(
                name: "Page");

            migrationBuilder.DropTable(
                name: "Publishers");

            migrationBuilder.DropTable(
                name: "Translator");

            migrationBuilder.DropTable(
                name: "AuthorFirst");

            migrationBuilder.DropTable(
                name: "AuthorSecond");

            migrationBuilder.DropTable(
                name: "PagesNumber");

            migrationBuilder.DropTable(
                name: "PagesRange");

            migrationBuilder.DropTable(
                name: "PublishVolume");

            migrationBuilder.DropTable(
                name: "Publisher");

            migrationBuilder.DropTable(
                name: "PublishUniver");

            migrationBuilder.DropTable(
                name: "Title");

            migrationBuilder.DropTable(
                name: "TitleOfConference");

            migrationBuilder.DropTable(
                name: "Webdoc");

            migrationBuilder.DropTable(
                name: "YearDate");

            migrationBuilder.DropTable(
                name: "Label");

            migrationBuilder.DropTable(
                name: "Name");

            migrationBuilder.DropTable(
                name: "GroupPublisher");

            migrationBuilder.DropTable(
                name: "YearDatePublisher");

            migrationBuilder.DropTable(
                name: "GroupUniver");

            migrationBuilder.DropTable(
                name: "YearDateUniver");

            migrationBuilder.DropTable(
                name: "Texts");

            migrationBuilder.DropTable(
                name: "Date");

            migrationBuilder.DropTable(
                name: "DatePublisher");

            migrationBuilder.DropTable(
                name: "DateUniver");

            migrationBuilder.DropTable(
                name: "Group");
        }
    }
}
