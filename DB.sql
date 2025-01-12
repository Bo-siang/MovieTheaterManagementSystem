USE [master]
GO
/****** Object:  Database [MovieTheaterManagement]    Script Date: 2024/2/22 下午 05:47:47 ******/
CREATE DATABASE [MovieTheaterManagement]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'MovieTheaterManagement', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\MovieTheaterManagement.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'MovieTheaterManagement_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\MovieTheaterManagement_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
GO
ALTER DATABASE [MovieTheaterManagement] SET COMPATIBILITY_LEVEL = 160
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [MovieTheaterManagement].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [MovieTheaterManagement] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [MovieTheaterManagement] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [MovieTheaterManagement] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [MovieTheaterManagement] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [MovieTheaterManagement] SET ARITHABORT OFF 
GO
ALTER DATABASE [MovieTheaterManagement] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [MovieTheaterManagement] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [MovieTheaterManagement] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [MovieTheaterManagement] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [MovieTheaterManagement] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [MovieTheaterManagement] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [MovieTheaterManagement] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [MovieTheaterManagement] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [MovieTheaterManagement] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [MovieTheaterManagement] SET  DISABLE_BROKER 
GO
ALTER DATABASE [MovieTheaterManagement] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [MovieTheaterManagement] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [MovieTheaterManagement] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [MovieTheaterManagement] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [MovieTheaterManagement] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [MovieTheaterManagement] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [MovieTheaterManagement] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [MovieTheaterManagement] SET RECOVERY FULL 
GO
ALTER DATABASE [MovieTheaterManagement] SET  MULTI_USER 
GO
ALTER DATABASE [MovieTheaterManagement] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [MovieTheaterManagement] SET DB_CHAINING OFF 
GO
ALTER DATABASE [MovieTheaterManagement] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [MovieTheaterManagement] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [MovieTheaterManagement] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [MovieTheaterManagement] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'MovieTheaterManagement', N'ON'
GO
ALTER DATABASE [MovieTheaterManagement] SET QUERY_STORE = ON
GO
ALTER DATABASE [MovieTheaterManagement] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
USE [MovieTheaterManagement]
GO
/****** Object:  Table [dbo].[user]    Script Date: 2024/2/22 下午 05:47:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[user](
	[user_id] [int] IDENTITY(0,1) NOT NULL,
	[role] [varchar](15) NOT NULL,
	[user_name] [nvarchar](50) NOT NULL,
	[email] [varchar](50) NOT NULL,
	[password] [varchar](50) NOT NULL,
	[register_datetime] [datetime] NOT NULL,
 CONSTRAINT [PK_user] PRIMARY KEY CLUSTERED 
(
	[user_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  View [dbo].[view_member]    Script Date: 2024/2/22 下午 05:47:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create view [dbo].[view_member] as select * from [user] where role = 'mb';
GO
/****** Object:  Table [dbo].[hall]    Script Date: 2024/2/22 下午 05:47:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[hall](
	[hall_id] [char](10) NOT NULL,
	[hall_type] [varchar](50) NOT NULL,
 CONSTRAINT [PK_hall_1] PRIMARY KEY CLUSTERED 
(
	[hall_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[movie]    Script Date: 2024/2/22 下午 05:47:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[movie](
	[movie_id] [int] IDENTITY(1,1) NOT NULL,
	[movie_name] [nvarchar](150) NOT NULL,
	[type] [nvarchar](100) NOT NULL,
	[director] [nvarchar](100) NOT NULL,
	[duration] [int] NOT NULL,
	[poster_url] [nvarchar](200) NOT NULL,
	[trailer_url] [nvarchar](500) NOT NULL,
	[top3] [bit] NOT NULL,
	[release_date] [date] NOT NULL,
 CONSTRAINT [PK_movie] PRIMARY KEY CLUSTERED 
(
	[movie_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[schedule]    Script Date: 2024/2/22 下午 05:47:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[schedule](
	[schedule_id] [int] IDENTITY(1,1) NOT NULL,
	[movie_id] [int] NOT NULL,
	[hall_id] [char](10) NOT NULL,
	[showing_time] [datetime] NOT NULL,
 CONSTRAINT [PK_schedule] PRIMARY KEY CLUSTERED 
(
	[schedule_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[seat_status]    Script Date: 2024/2/22 下午 05:47:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[seat_status](
	[schedule_id] [int] NOT NULL,
	[a1] [bit] NOT NULL,
	[a2] [bit] NOT NULL,
	[a3] [bit] NOT NULL,
	[a4] [bit] NOT NULL,
	[a5] [bit] NOT NULL,
	[b1] [bit] NOT NULL,
	[b2] [bit] NOT NULL,
	[b3] [bit] NOT NULL,
	[b4] [bit] NOT NULL,
	[b5] [bit] NOT NULL,
	[c1] [bit] NOT NULL,
	[c2] [bit] NOT NULL,
	[c3] [bit] NOT NULL,
	[c4] [bit] NOT NULL,
	[c5] [bit] NOT NULL,
 CONSTRAINT [PK_seat_status] PRIMARY KEY CLUSTERED 
(
	[schedule_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ticket]    Script Date: 2024/2/22 下午 05:47:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ticket](
	[ticket_id] [int] IDENTITY(1,1) NOT NULL,
	[user_id] [int] NOT NULL,
	[schedule_id] [int] NOT NULL,
	[seat] [varchar](50) NOT NULL,
	[adult_num] [int] NOT NULL,
	[elder_num] [int] NOT NULL,
	[child_num] [int] NOT NULL,
	[student_num] [int] NOT NULL,
	[total_price] [int] NOT NULL,
	[order_datetime] [datetime] NOT NULL,
 CONSTRAINT [PK_ticket] PRIMARY KEY CLUSTERED 
(
	[ticket_id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[hall] ([hall_id], [hall_type]) VALUES (N'F1H1      ', N'2D')
INSERT [dbo].[hall] ([hall_id], [hall_type]) VALUES (N'F1H2      ', N'2D')
INSERT [dbo].[hall] ([hall_id], [hall_type]) VALUES (N'F1H3      ', N'IMAX')
INSERT [dbo].[hall] ([hall_id], [hall_type]) VALUES (N'F2H1      ', N'4DX')
INSERT [dbo].[hall] ([hall_id], [hall_type]) VALUES (N'F2H2      ', N'3D')
GO
SET IDENTITY_INSERT [dbo].[movie] ON 

INSERT [dbo].[movie] ([movie_id], [movie_name], [type], [director], [duration], [poster_url], [trailer_url], [top3], [release_date]) VALUES (1, N'ブラックアダム', N'スーパーヒーロー', N'ジャウム・コレット＝セラ', 125, N'blackAdam.jpg', N'映画『ブラックアダム』本編映像（アクション編）大ヒット上映中.mp4', 0, CAST(N'2022-10-19' AS Date))
INSERT [dbo].[movie] ([movie_id], [movie_name], [type], [director], [duration], [poster_url], [trailer_url], [top3], [release_date]) VALUES (7, N'AIR/エア', N'スポーツ', N'ベン・アフレック', 112, N'air.jpg', N'映画『AIR_エア』予告 2023年4月7日（金）公開.mp4', 0, CAST(N'2023-04-16' AS Date))
INSERT [dbo].[movie] ([movie_id], [movie_name], [type], [director], [duration], [poster_url], [trailer_url], [top3], [release_date]) VALUES (14, N'スーパーマリオ」', N'アニメ', N'アーロン・ホーバス マイケル・イェレニック', 120, N'mario.jpg', N'任天堂「スーパーマリオ」が映画化！『ザ・スーパーマリオブラザーズ・ムービー』トレーラー映像.mp4', 1, CAST(N'2023-04-16' AS Date))
INSERT [dbo].[movie] ([movie_id], [movie_name], [type], [director], [duration], [poster_url], [trailer_url], [top3], [release_date]) VALUES (35, N'世界の終わりから', N'冒険', N'紀里谷和明', 135, N'endOfWorld.jpg', N'映画『世界の終わりから』本予告.mp4', 0, CAST(N'2023-04-05' AS Date))
INSERT [dbo].[movie] ([movie_id], [movie_name], [type], [director], [duration], [poster_url], [trailer_url], [top3], [release_date]) VALUES (44, N'TOKYO MER～走る緊急救命室', N'ヒューマン', N'松木彩', 128, N'emergency.jpg', N'【最新予告】劇場版『TOKYO MER～走る緊急救命室～』予告②《2023年4月28日(金)公開》.mp4', 0, CAST(N'2023-04-28' AS Date))
INSERT [dbo].[movie] ([movie_id], [movie_name], [type], [director], [duration], [poster_url], [trailer_url], [top3], [release_date]) VALUES (52, N'THE FIRST SLAM DUNK', N'青春', N'井上', 124, N'basketball.jpg', N'映画『THE FIRST SLAM DUNK』予告【2022.12.3 公開】.mp4', 0, CAST(N'2022-12-03' AS Date))
INSERT [dbo].[movie] ([movie_id], [movie_name], [type], [director], [duration], [poster_url], [trailer_url], [top3], [release_date]) VALUES (63, N'ジュラシック・ワールド／新たなる支配者', N'サスペンス・ミステリー', N'コリン・トレヴォロウ', 147, N'dinosaur.jpg', N'映画『ジュラシック・ワールド／新たなる支配者』最新予告＜7月29日(金)全国公開＞.mp4', 1, CAST(N'2022-07-29' AS Date))
INSERT [dbo].[movie] ([movie_id], [movie_name], [type], [director], [duration], [poster_url], [trailer_url], [top3], [release_date]) VALUES (73, N'ファンタスティック・ビーストとダンブルドアの秘密', N'冒険', N'デヴィッド・イェーツ', 143, N'sorcerer.jpg', N'映画『ファンタスティック・ビーストとダンブルドアの秘密』本予告 2022年4月8日（金）公開.mp4', 0, CAST(N'2022-04-08' AS Date))
INSERT [dbo].[movie] ([movie_id], [movie_name], [type], [director], [duration], [poster_url], [trailer_url], [top3], [release_date]) VALUES (80, N'映画ドラえもん のび太と空の理想郷', N'アニメ', N'堂山卓見', 108, N'doraemon.jpg', N'『映画ドラえもん のび太と空の理想郷』予告編（前売券＆入場者プレゼント情報付き）.mp4', 0, CAST(N'2023-03-03' AS Date))
INSERT [dbo].[movie] ([movie_id], [movie_name], [type], [director], [duration], [poster_url], [trailer_url], [top3], [release_date]) VALUES (85, N'あの男', N'神秘', N'石川慶', 121, N'aMan.jpg', N'映画『ある男』本予告【2022年11月18日(金)ロードショー】.mp4', 1, CAST(N'2022-11-08' AS Date))
INSERT [dbo].[movie] ([movie_id], [movie_name], [type], [director], [duration], [poster_url], [trailer_url], [top3], [release_date]) VALUES (90, N'トップガン マーヴェリック', N'アクション', N'ジョセフ・コシンスキー', 130, N'topGun.jpg', N'映画『トップガン マーヴェリック』ファイナル予告.mp4', 0, CAST(N'2022-05-27' AS Date))
INSERT [dbo].[movie] ([movie_id], [movie_name], [type], [director], [duration], [poster_url], [trailer_url], [top3], [release_date]) VALUES (94, N'幻滅', N'ヒューマンドラマ', N'グザヴィエ・ジャノリ', 149, N'main.jpg', N'2022年セザール賞7冠！映画『幻滅』予告編.mp4', 0, CAST(N'2023-04-14' AS Date))
INSERT [dbo].[movie] ([movie_id], [movie_name], [type], [director], [duration], [poster_url], [trailer_url], [top3], [release_date]) VALUES (99, N'聖地には蜘蛛が巣を張る', N'サスペンス・ミステリー', N'アリ・アッバシ', 118, N'spider.jpg', N'映画『聖地には蜘蛛が巣を張る』本予告【4_14（金）全国公開】.mp4', 0, CAST(N'2023-04-14' AS Date))
INSERT [dbo].[movie] ([movie_id], [movie_name], [type], [director], [duration], [poster_url], [trailer_url], [top3], [release_date]) VALUES (101, N'見知らぬ隣人', N'サスペンス・ミステリー', N'Yeom Ji-ho', 93, N'stranger.jpg', N'映画『見知らぬ隣人』予告編.mp4', 0, CAST(N'2023-04-14' AS Date))
INSERT [dbo].[movie] ([movie_id], [movie_name], [type], [director], [duration], [poster_url], [trailer_url], [top3], [release_date]) VALUES (104, N'ノック 終末の訪問者', N'ホラー', N'M・ナイト・シャマラン', 100, N'visitor.jpg', N'映画『ノック 終末の訪問者』本予告＜2023年4月7日（金）全国公開＞.mp4', 0, CAST(N'2023-04-07' AS Date))
INSERT [dbo].[movie] ([movie_id], [movie_name], [type], [director], [duration], [poster_url], [trailer_url], [top3], [release_date]) VALUES (106, N'ザ・ホエール', N'ヒューマンドラマ', N'ダーレン・アロノフスキー', 117, N'whale.jpg', N'アカデミー賞2冠_4_7公開『ザ・ホエール』予告篇.mp4', 0, CAST(N'2023-04-07' AS Date))
INSERT [dbo].[movie] ([movie_id], [movie_name], [type], [director], [duration], [poster_url], [trailer_url], [top3], [release_date]) VALUES (109, N'ノートルダム 炎の大聖堂', N'社会派', N'ジャン＝ジャック・アノー', 110, N'fire.jpg', N'「死者ゼロ」の奇跡、圧巻のリアリティ＆臨場感で映画化『ノートルダム 炎の大聖堂』予告編【2023年4月7日公開】.mp4', 0, CAST(N'2023-04-07' AS Date))
INSERT [dbo].[movie] ([movie_id], [movie_name], [type], [director], [duration], [poster_url], [trailer_url], [top3], [release_date]) VALUES (111, N'生きる LIVING', N'ヒューマンドラマ', N'オリヴァー・ハーマナス', 103, N'living.jpg', N'予告＞『生きるLIVING』【3_31公開】.mp4', 0, CAST(N'2023-03-31' AS Date))
INSERT [dbo].[movie] ([movie_id], [movie_name], [type], [director], [duration], [poster_url], [trailer_url], [top3], [release_date]) VALUES (115, N'シング・フォー・ミー、ライル', N'ミュージカル', N'ウィル・スペック · ジョシュ・ゴードン', 106, N'crocodile.jpg', N'ミュージカル映画『シング・フォー・ミー、ライル』＜日本語吹替版予告＞ 3月24日（金） 全国の映画館で公開.mp4', 0, CAST(N'2023-03-24' AS Date))
INSERT [dbo].[movie] ([movie_id], [movie_name], [type], [director], [duration], [poster_url], [trailer_url], [top3], [release_date]) VALUES (117, N'郊外の豚たち', N'ヒューマンドラマ', N'チウ・ション', 140, N'bird.jpg', N'映画『郊外の鳥たち』予告編.mp4', 0, CAST(N'2023-03-18' AS Date))
INSERT [dbo].[movie] ([movie_id], [movie_name], [type], [director], [duration], [poster_url], [trailer_url], [top3], [release_date]) VALUES (120, N'高速道路家族', N'ヒューマン', N'イサンム', 124, N'highway.jpeg', N'映画『高速道路家族』予告【4.21(Fri)公開】.mp4', 0, CAST(N'2023-04-21' AS Date))
SET IDENTITY_INSERT [dbo].[movie] OFF
GO
SET IDENTITY_INSERT [dbo].[schedule] ON 

INSERT [dbo].[schedule] ([schedule_id], [movie_id], [hall_id], [showing_time]) VALUES (2, 1, N'F1H1      ', CAST(N'2023-04-06T10:30:00.000' AS DateTime))
INSERT [dbo].[schedule] ([schedule_id], [movie_id], [hall_id], [showing_time]) VALUES (5, 1, N'F1H1      ', CAST(N'2023-04-06T15:00:00.000' AS DateTime))
INSERT [dbo].[schedule] ([schedule_id], [movie_id], [hall_id], [showing_time]) VALUES (8, 1, N'F1H1      ', CAST(N'2023-04-07T11:00:00.000' AS DateTime))
INSERT [dbo].[schedule] ([schedule_id], [movie_id], [hall_id], [showing_time]) VALUES (11, 1, N'F1H1      ', CAST(N'2023-04-07T14:30:00.000' AS DateTime))
INSERT [dbo].[schedule] ([schedule_id], [movie_id], [hall_id], [showing_time]) VALUES (14, 7, N'F1H2      ', CAST(N'2023-04-20T10:30:00.000' AS DateTime))
INSERT [dbo].[schedule] ([schedule_id], [movie_id], [hall_id], [showing_time]) VALUES (16, 7, N'F1H2      ', CAST(N'2023-04-20T14:30:00.000' AS DateTime))
INSERT [dbo].[schedule] ([schedule_id], [movie_id], [hall_id], [showing_time]) VALUES (18, 7, N'F1H2      ', CAST(N'2023-04-20T17:00:00.000' AS DateTime))
INSERT [dbo].[schedule] ([schedule_id], [movie_id], [hall_id], [showing_time]) VALUES (21, 14, N'F1H3      ', CAST(N'2023-04-20T13:00:00.000' AS DateTime))
INSERT [dbo].[schedule] ([schedule_id], [movie_id], [hall_id], [showing_time]) VALUES (25, 14, N'F1H3      ', CAST(N'2023-04-20T17:00:00.000' AS DateTime))
INSERT [dbo].[schedule] ([schedule_id], [movie_id], [hall_id], [showing_time]) VALUES (28, 44, N'F1H1      ', CAST(N'2023-04-28T13:25:00.000' AS DateTime))
INSERT [dbo].[schedule] ([schedule_id], [movie_id], [hall_id], [showing_time]) VALUES (29, 44, N'F1H2      ', CAST(N'2023-04-28T20:00:00.000' AS DateTime))
INSERT [dbo].[schedule] ([schedule_id], [movie_id], [hall_id], [showing_time]) VALUES (32, 44, N'F1H2      ', CAST(N'2023-04-28T22:00:00.000' AS DateTime))
INSERT [dbo].[schedule] ([schedule_id], [movie_id], [hall_id], [showing_time]) VALUES (36, 44, N'F1H3      ', CAST(N'2023-04-29T09:50:00.000' AS DateTime))
INSERT [dbo].[schedule] ([schedule_id], [movie_id], [hall_id], [showing_time]) VALUES (38, 44, N'F1H2      ', CAST(N'2023-04-29T11:30:00.000' AS DateTime))
INSERT [dbo].[schedule] ([schedule_id], [movie_id], [hall_id], [showing_time]) VALUES (40, 44, N'F1H2      ', CAST(N'2023-04-23T14:50:00.000' AS DateTime))
INSERT [dbo].[schedule] ([schedule_id], [movie_id], [hall_id], [showing_time]) VALUES (42, 14, N'F2H1      ', CAST(N'2023-04-20T17:00:00.000' AS DateTime))
INSERT [dbo].[schedule] ([schedule_id], [movie_id], [hall_id], [showing_time]) VALUES (44, 35, N'F1H1      ', CAST(N'2023-04-05T11:00:00.000' AS DateTime))
INSERT [dbo].[schedule] ([schedule_id], [movie_id], [hall_id], [showing_time]) VALUES (46, 35, N'F1H1      ', CAST(N'2023-04-05T15:00:00.000' AS DateTime))
INSERT [dbo].[schedule] ([schedule_id], [movie_id], [hall_id], [showing_time]) VALUES (47, 1, N'F1H2      ', CAST(N'2023-04-25T10:30:00.000' AS DateTime))
INSERT [dbo].[schedule] ([schedule_id], [movie_id], [hall_id], [showing_time]) VALUES (48, 35, N'F1H3      ', CAST(N'2023-04-25T10:30:00.000' AS DateTime))
INSERT [dbo].[schedule] ([schedule_id], [movie_id], [hall_id], [showing_time]) VALUES (53, 35, N'F2H2      ', CAST(N'2023-04-21T13:00:00.000' AS DateTime))
INSERT [dbo].[schedule] ([schedule_id], [movie_id], [hall_id], [showing_time]) VALUES (54, 35, N'F1H2      ', CAST(N'2023-04-21T16:00:00.000' AS DateTime))
INSERT [dbo].[schedule] ([schedule_id], [movie_id], [hall_id], [showing_time]) VALUES (55, 35, N'F1H2      ', CAST(N'2023-04-21T20:00:00.000' AS DateTime))
INSERT [dbo].[schedule] ([schedule_id], [movie_id], [hall_id], [showing_time]) VALUES (56, 35, N'F1H2      ', CAST(N'2023-04-22T10:35:00.000' AS DateTime))
INSERT [dbo].[schedule] ([schedule_id], [movie_id], [hall_id], [showing_time]) VALUES (57, 35, N'F1H2      ', CAST(N'2023-04-22T14:40:00.000' AS DateTime))
INSERT [dbo].[schedule] ([schedule_id], [movie_id], [hall_id], [showing_time]) VALUES (58, 35, N'F1H2      ', CAST(N'2023-04-22T18:50:00.000' AS DateTime))
INSERT [dbo].[schedule] ([schedule_id], [movie_id], [hall_id], [showing_time]) VALUES (59, 35, N'F1H2      ', CAST(N'2023-04-23T14:00:00.000' AS DateTime))
INSERT [dbo].[schedule] ([schedule_id], [movie_id], [hall_id], [showing_time]) VALUES (60, 35, N'F1H2      ', CAST(N'2023-04-23T19:00:00.000' AS DateTime))
INSERT [dbo].[schedule] ([schedule_id], [movie_id], [hall_id], [showing_time]) VALUES (65, 44, N'F1H1      ', CAST(N'2023-04-28T12:30:00.000' AS DateTime))
INSERT [dbo].[schedule] ([schedule_id], [movie_id], [hall_id], [showing_time]) VALUES (66, 44, N'F1H1      ', CAST(N'2023-04-28T15:30:00.000' AS DateTime))
INSERT [dbo].[schedule] ([schedule_id], [movie_id], [hall_id], [showing_time]) VALUES (67, 44, N'F1H3      ', CAST(N'2023-04-29T15:30:00.000' AS DateTime))
INSERT [dbo].[schedule] ([schedule_id], [movie_id], [hall_id], [showing_time]) VALUES (68, 44, N'F1H3      ', CAST(N'2023-04-29T17:50:00.000' AS DateTime))
INSERT [dbo].[schedule] ([schedule_id], [movie_id], [hall_id], [showing_time]) VALUES (69, 44, N'F1H3      ', CAST(N'2023-04-29T20:30:00.000' AS DateTime))
INSERT [dbo].[schedule] ([schedule_id], [movie_id], [hall_id], [showing_time]) VALUES (70, 44, N'F1H3      ', CAST(N'2023-04-30T11:00:00.000' AS DateTime))
INSERT [dbo].[schedule] ([schedule_id], [movie_id], [hall_id], [showing_time]) VALUES (71, 44, N'F1H3      ', CAST(N'2023-04-30T14:50:00.000' AS DateTime))
INSERT [dbo].[schedule] ([schedule_id], [movie_id], [hall_id], [showing_time]) VALUES (72, 44, N'F1H3      ', CAST(N'2023-04-30T18:30:00.000' AS DateTime))
INSERT [dbo].[schedule] ([schedule_id], [movie_id], [hall_id], [showing_time]) VALUES (73, 80, N'F1H3      ', CAST(N'2023-03-03T13:30:00.000' AS DateTime))
INSERT [dbo].[schedule] ([schedule_id], [movie_id], [hall_id], [showing_time]) VALUES (74, 80, N'F2H1      ', CAST(N'2023-03-03T17:00:00.000' AS DateTime))
INSERT [dbo].[schedule] ([schedule_id], [movie_id], [hall_id], [showing_time]) VALUES (75, 94, N'F2H1      ', CAST(N'2023-04-25T12:00:00.000' AS DateTime))
INSERT [dbo].[schedule] ([schedule_id], [movie_id], [hall_id], [showing_time]) VALUES (76, 94, N'F2H1      ', CAST(N'2023-04-25T16:50:00.000' AS DateTime))
INSERT [dbo].[schedule] ([schedule_id], [movie_id], [hall_id], [showing_time]) VALUES (77, 94, N'F2H1      ', CAST(N'2023-04-25T19:35:00.000' AS DateTime))
INSERT [dbo].[schedule] ([schedule_id], [movie_id], [hall_id], [showing_time]) VALUES (78, 99, N'F1H2      ', CAST(N'2023-04-25T11:10:00.000' AS DateTime))
INSERT [dbo].[schedule] ([schedule_id], [movie_id], [hall_id], [showing_time]) VALUES (79, 99, N'F1H2      ', CAST(N'2023-04-25T15:30:00.000' AS DateTime))
INSERT [dbo].[schedule] ([schedule_id], [movie_id], [hall_id], [showing_time]) VALUES (80, 99, N'F1H2      ', CAST(N'2023-04-25T21:00:00.000' AS DateTime))
INSERT [dbo].[schedule] ([schedule_id], [movie_id], [hall_id], [showing_time]) VALUES (81, 101, N'F1H1      ', CAST(N'2023-04-25T11:00:00.000' AS DateTime))
INSERT [dbo].[schedule] ([schedule_id], [movie_id], [hall_id], [showing_time]) VALUES (82, 101, N'F1H1      ', CAST(N'2023-04-25T15:40:00.000' AS DateTime))
INSERT [dbo].[schedule] ([schedule_id], [movie_id], [hall_id], [showing_time]) VALUES (83, 101, N'F2H1      ', CAST(N'2023-04-14T10:00:00.000' AS DateTime))
INSERT [dbo].[schedule] ([schedule_id], [movie_id], [hall_id], [showing_time]) VALUES (84, 101, N'F2H1      ', CAST(N'2023-04-15T10:00:00.000' AS DateTime))
INSERT [dbo].[schedule] ([schedule_id], [movie_id], [hall_id], [showing_time]) VALUES (85, 101, N'F2H1      ', CAST(N'2023-04-16T10:00:00.000' AS DateTime))
INSERT [dbo].[schedule] ([schedule_id], [movie_id], [hall_id], [showing_time]) VALUES (86, 101, N'F2H1      ', CAST(N'2023-04-17T10:00:00.000' AS DateTime))
INSERT [dbo].[schedule] ([schedule_id], [movie_id], [hall_id], [showing_time]) VALUES (87, 101, N'F2H1      ', CAST(N'2023-04-18T10:00:00.000' AS DateTime))
INSERT [dbo].[schedule] ([schedule_id], [movie_id], [hall_id], [showing_time]) VALUES (88, 101, N'F2H1      ', CAST(N'2023-04-19T10:00:00.000' AS DateTime))
INSERT [dbo].[schedule] ([schedule_id], [movie_id], [hall_id], [showing_time]) VALUES (89, 101, N'F2H1      ', CAST(N'2023-04-20T10:00:00.000' AS DateTime))
INSERT [dbo].[schedule] ([schedule_id], [movie_id], [hall_id], [showing_time]) VALUES (90, 101, N'F2H1      ', CAST(N'2023-04-21T10:00:00.000' AS DateTime))
INSERT [dbo].[schedule] ([schedule_id], [movie_id], [hall_id], [showing_time]) VALUES (91, 101, N'F2H1      ', CAST(N'2023-04-22T10:00:00.000' AS DateTime))
INSERT [dbo].[schedule] ([schedule_id], [movie_id], [hall_id], [showing_time]) VALUES (92, 101, N'F2H1      ', CAST(N'2023-04-23T10:00:00.000' AS DateTime))
INSERT [dbo].[schedule] ([schedule_id], [movie_id], [hall_id], [showing_time]) VALUES (93, 101, N'F2H1      ', CAST(N'2023-04-24T10:00:00.000' AS DateTime))
INSERT [dbo].[schedule] ([schedule_id], [movie_id], [hall_id], [showing_time]) VALUES (94, 101, N'F2H1      ', CAST(N'2023-04-25T10:00:00.000' AS DateTime))
INSERT [dbo].[schedule] ([schedule_id], [movie_id], [hall_id], [showing_time]) VALUES (95, 101, N'F2H1      ', CAST(N'2023-04-26T10:00:00.000' AS DateTime))
INSERT [dbo].[schedule] ([schedule_id], [movie_id], [hall_id], [showing_time]) VALUES (96, 101, N'F2H1      ', CAST(N'2023-04-27T10:00:00.000' AS DateTime))
INSERT [dbo].[schedule] ([schedule_id], [movie_id], [hall_id], [showing_time]) VALUES (97, 101, N'F2H1      ', CAST(N'2023-04-28T10:00:00.000' AS DateTime))
INSERT [dbo].[schedule] ([schedule_id], [movie_id], [hall_id], [showing_time]) VALUES (98, 101, N'F2H1      ', CAST(N'2023-04-29T10:00:00.000' AS DateTime))
INSERT [dbo].[schedule] ([schedule_id], [movie_id], [hall_id], [showing_time]) VALUES (99, 101, N'F2H1      ', CAST(N'2023-04-30T10:00:00.000' AS DateTime))
INSERT [dbo].[schedule] ([schedule_id], [movie_id], [hall_id], [showing_time]) VALUES (100, 7, N'F1H2      ', CAST(N'2023-04-20T12:40:00.000' AS DateTime))
SET IDENTITY_INSERT [dbo].[schedule] OFF
GO
INSERT [dbo].[seat_status] ([schedule_id], [a1], [a2], [a3], [a4], [a5], [b1], [b2], [b3], [b4], [b5], [c1], [c2], [c3], [c4], [c5]) VALUES (2, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0)
INSERT [dbo].[seat_status] ([schedule_id], [a1], [a2], [a3], [a4], [a5], [b1], [b2], [b3], [b4], [b5], [c1], [c2], [c3], [c4], [c5]) VALUES (5, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0)
INSERT [dbo].[seat_status] ([schedule_id], [a1], [a2], [a3], [a4], [a5], [b1], [b2], [b3], [b4], [b5], [c1], [c2], [c3], [c4], [c5]) VALUES (8, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0)
INSERT [dbo].[seat_status] ([schedule_id], [a1], [a2], [a3], [a4], [a5], [b1], [b2], [b3], [b4], [b5], [c1], [c2], [c3], [c4], [c5]) VALUES (11, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0)
INSERT [dbo].[seat_status] ([schedule_id], [a1], [a2], [a3], [a4], [a5], [b1], [b2], [b3], [b4], [b5], [c1], [c2], [c3], [c4], [c5]) VALUES (14, 1, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0)
INSERT [dbo].[seat_status] ([schedule_id], [a1], [a2], [a3], [a4], [a5], [b1], [b2], [b3], [b4], [b5], [c1], [c2], [c3], [c4], [c5]) VALUES (16, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0)
INSERT [dbo].[seat_status] ([schedule_id], [a1], [a2], [a3], [a4], [a5], [b1], [b2], [b3], [b4], [b5], [c1], [c2], [c3], [c4], [c5]) VALUES (18, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0)
INSERT [dbo].[seat_status] ([schedule_id], [a1], [a2], [a3], [a4], [a5], [b1], [b2], [b3], [b4], [b5], [c1], [c2], [c3], [c4], [c5]) VALUES (21, 0, 0, 1, 1, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0)
INSERT [dbo].[seat_status] ([schedule_id], [a1], [a2], [a3], [a4], [a5], [b1], [b2], [b3], [b4], [b5], [c1], [c2], [c3], [c4], [c5]) VALUES (25, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0)
INSERT [dbo].[seat_status] ([schedule_id], [a1], [a2], [a3], [a4], [a5], [b1], [b2], [b3], [b4], [b5], [c1], [c2], [c3], [c4], [c5]) VALUES (28, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0)
INSERT [dbo].[seat_status] ([schedule_id], [a1], [a2], [a3], [a4], [a5], [b1], [b2], [b3], [b4], [b5], [c1], [c2], [c3], [c4], [c5]) VALUES (29, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0)
INSERT [dbo].[seat_status] ([schedule_id], [a1], [a2], [a3], [a4], [a5], [b1], [b2], [b3], [b4], [b5], [c1], [c2], [c3], [c4], [c5]) VALUES (32, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0)
INSERT [dbo].[seat_status] ([schedule_id], [a1], [a2], [a3], [a4], [a5], [b1], [b2], [b3], [b4], [b5], [c1], [c2], [c3], [c4], [c5]) VALUES (36, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0)
INSERT [dbo].[seat_status] ([schedule_id], [a1], [a2], [a3], [a4], [a5], [b1], [b2], [b3], [b4], [b5], [c1], [c2], [c3], [c4], [c5]) VALUES (38, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0)
INSERT [dbo].[seat_status] ([schedule_id], [a1], [a2], [a3], [a4], [a5], [b1], [b2], [b3], [b4], [b5], [c1], [c2], [c3], [c4], [c5]) VALUES (40, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0)
INSERT [dbo].[seat_status] ([schedule_id], [a1], [a2], [a3], [a4], [a5], [b1], [b2], [b3], [b4], [b5], [c1], [c2], [c3], [c4], [c5]) VALUES (42, 1, 0, 1, 1, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0)
INSERT [dbo].[seat_status] ([schedule_id], [a1], [a2], [a3], [a4], [a5], [b1], [b2], [b3], [b4], [b5], [c1], [c2], [c3], [c4], [c5]) VALUES (44, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0)
INSERT [dbo].[seat_status] ([schedule_id], [a1], [a2], [a3], [a4], [a5], [b1], [b2], [b3], [b4], [b5], [c1], [c2], [c3], [c4], [c5]) VALUES (46, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0)
INSERT [dbo].[seat_status] ([schedule_id], [a1], [a2], [a3], [a4], [a5], [b1], [b2], [b3], [b4], [b5], [c1], [c2], [c3], [c4], [c5]) VALUES (47, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0)
INSERT [dbo].[seat_status] ([schedule_id], [a1], [a2], [a3], [a4], [a5], [b1], [b2], [b3], [b4], [b5], [c1], [c2], [c3], [c4], [c5]) VALUES (48, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1, 0, 0)
INSERT [dbo].[seat_status] ([schedule_id], [a1], [a2], [a3], [a4], [a5], [b1], [b2], [b3], [b4], [b5], [c1], [c2], [c3], [c4], [c5]) VALUES (53, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0)
INSERT [dbo].[seat_status] ([schedule_id], [a1], [a2], [a3], [a4], [a5], [b1], [b2], [b3], [b4], [b5], [c1], [c2], [c3], [c4], [c5]) VALUES (54, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0)
INSERT [dbo].[seat_status] ([schedule_id], [a1], [a2], [a3], [a4], [a5], [b1], [b2], [b3], [b4], [b5], [c1], [c2], [c3], [c4], [c5]) VALUES (55, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0)
INSERT [dbo].[seat_status] ([schedule_id], [a1], [a2], [a3], [a4], [a5], [b1], [b2], [b3], [b4], [b5], [c1], [c2], [c3], [c4], [c5]) VALUES (56, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0)
INSERT [dbo].[seat_status] ([schedule_id], [a1], [a2], [a3], [a4], [a5], [b1], [b2], [b3], [b4], [b5], [c1], [c2], [c3], [c4], [c5]) VALUES (57, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0)
INSERT [dbo].[seat_status] ([schedule_id], [a1], [a2], [a3], [a4], [a5], [b1], [b2], [b3], [b4], [b5], [c1], [c2], [c3], [c4], [c5]) VALUES (58, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0)
INSERT [dbo].[seat_status] ([schedule_id], [a1], [a2], [a3], [a4], [a5], [b1], [b2], [b3], [b4], [b5], [c1], [c2], [c3], [c4], [c5]) VALUES (59, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0)
INSERT [dbo].[seat_status] ([schedule_id], [a1], [a2], [a3], [a4], [a5], [b1], [b2], [b3], [b4], [b5], [c1], [c2], [c3], [c4], [c5]) VALUES (60, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0)
INSERT [dbo].[seat_status] ([schedule_id], [a1], [a2], [a3], [a4], [a5], [b1], [b2], [b3], [b4], [b5], [c1], [c2], [c3], [c4], [c5]) VALUES (65, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0)
INSERT [dbo].[seat_status] ([schedule_id], [a1], [a2], [a3], [a4], [a5], [b1], [b2], [b3], [b4], [b5], [c1], [c2], [c3], [c4], [c5]) VALUES (66, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0)
INSERT [dbo].[seat_status] ([schedule_id], [a1], [a2], [a3], [a4], [a5], [b1], [b2], [b3], [b4], [b5], [c1], [c2], [c3], [c4], [c5]) VALUES (67, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0)
INSERT [dbo].[seat_status] ([schedule_id], [a1], [a2], [a3], [a4], [a5], [b1], [b2], [b3], [b4], [b5], [c1], [c2], [c3], [c4], [c5]) VALUES (68, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0)
INSERT [dbo].[seat_status] ([schedule_id], [a1], [a2], [a3], [a4], [a5], [b1], [b2], [b3], [b4], [b5], [c1], [c2], [c3], [c4], [c5]) VALUES (69, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0)
INSERT [dbo].[seat_status] ([schedule_id], [a1], [a2], [a3], [a4], [a5], [b1], [b2], [b3], [b4], [b5], [c1], [c2], [c3], [c4], [c5]) VALUES (70, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0)
INSERT [dbo].[seat_status] ([schedule_id], [a1], [a2], [a3], [a4], [a5], [b1], [b2], [b3], [b4], [b5], [c1], [c2], [c3], [c4], [c5]) VALUES (71, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0)
INSERT [dbo].[seat_status] ([schedule_id], [a1], [a2], [a3], [a4], [a5], [b1], [b2], [b3], [b4], [b5], [c1], [c2], [c3], [c4], [c5]) VALUES (72, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0)
INSERT [dbo].[seat_status] ([schedule_id], [a1], [a2], [a3], [a4], [a5], [b1], [b2], [b3], [b4], [b5], [c1], [c2], [c3], [c4], [c5]) VALUES (73, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0)
INSERT [dbo].[seat_status] ([schedule_id], [a1], [a2], [a3], [a4], [a5], [b1], [b2], [b3], [b4], [b5], [c1], [c2], [c3], [c4], [c5]) VALUES (74, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0)
INSERT [dbo].[seat_status] ([schedule_id], [a1], [a2], [a3], [a4], [a5], [b1], [b2], [b3], [b4], [b5], [c1], [c2], [c3], [c4], [c5]) VALUES (75, 0, 0, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0)
INSERT [dbo].[seat_status] ([schedule_id], [a1], [a2], [a3], [a4], [a5], [b1], [b2], [b3], [b4], [b5], [c1], [c2], [c3], [c4], [c5]) VALUES (76, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0)
INSERT [dbo].[seat_status] ([schedule_id], [a1], [a2], [a3], [a4], [a5], [b1], [b2], [b3], [b4], [b5], [c1], [c2], [c3], [c4], [c5]) VALUES (77, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0)
INSERT [dbo].[seat_status] ([schedule_id], [a1], [a2], [a3], [a4], [a5], [b1], [b2], [b3], [b4], [b5], [c1], [c2], [c3], [c4], [c5]) VALUES (78, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0)
INSERT [dbo].[seat_status] ([schedule_id], [a1], [a2], [a3], [a4], [a5], [b1], [b2], [b3], [b4], [b5], [c1], [c2], [c3], [c4], [c5]) VALUES (79, 0, 0, 0, 0, 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0)
INSERT [dbo].[seat_status] ([schedule_id], [a1], [a2], [a3], [a4], [a5], [b1], [b2], [b3], [b4], [b5], [c1], [c2], [c3], [c4], [c5]) VALUES (80, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0)
INSERT [dbo].[seat_status] ([schedule_id], [a1], [a2], [a3], [a4], [a5], [b1], [b2], [b3], [b4], [b5], [c1], [c2], [c3], [c4], [c5]) VALUES (81, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0)
INSERT [dbo].[seat_status] ([schedule_id], [a1], [a2], [a3], [a4], [a5], [b1], [b2], [b3], [b4], [b5], [c1], [c2], [c3], [c4], [c5]) VALUES (82, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0)
INSERT [dbo].[seat_status] ([schedule_id], [a1], [a2], [a3], [a4], [a5], [b1], [b2], [b3], [b4], [b5], [c1], [c2], [c3], [c4], [c5]) VALUES (83, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0)
INSERT [dbo].[seat_status] ([schedule_id], [a1], [a2], [a3], [a4], [a5], [b1], [b2], [b3], [b4], [b5], [c1], [c2], [c3], [c4], [c5]) VALUES (84, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0)
INSERT [dbo].[seat_status] ([schedule_id], [a1], [a2], [a3], [a4], [a5], [b1], [b2], [b3], [b4], [b5], [c1], [c2], [c3], [c4], [c5]) VALUES (85, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0)
INSERT [dbo].[seat_status] ([schedule_id], [a1], [a2], [a3], [a4], [a5], [b1], [b2], [b3], [b4], [b5], [c1], [c2], [c3], [c4], [c5]) VALUES (86, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0)
INSERT [dbo].[seat_status] ([schedule_id], [a1], [a2], [a3], [a4], [a5], [b1], [b2], [b3], [b4], [b5], [c1], [c2], [c3], [c4], [c5]) VALUES (87, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0)
INSERT [dbo].[seat_status] ([schedule_id], [a1], [a2], [a3], [a4], [a5], [b1], [b2], [b3], [b4], [b5], [c1], [c2], [c3], [c4], [c5]) VALUES (88, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0)
INSERT [dbo].[seat_status] ([schedule_id], [a1], [a2], [a3], [a4], [a5], [b1], [b2], [b3], [b4], [b5], [c1], [c2], [c3], [c4], [c5]) VALUES (89, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0)
INSERT [dbo].[seat_status] ([schedule_id], [a1], [a2], [a3], [a4], [a5], [b1], [b2], [b3], [b4], [b5], [c1], [c2], [c3], [c4], [c5]) VALUES (90, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0)
INSERT [dbo].[seat_status] ([schedule_id], [a1], [a2], [a3], [a4], [a5], [b1], [b2], [b3], [b4], [b5], [c1], [c2], [c3], [c4], [c5]) VALUES (91, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0)
INSERT [dbo].[seat_status] ([schedule_id], [a1], [a2], [a3], [a4], [a5], [b1], [b2], [b3], [b4], [b5], [c1], [c2], [c3], [c4], [c5]) VALUES (92, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0)
INSERT [dbo].[seat_status] ([schedule_id], [a1], [a2], [a3], [a4], [a5], [b1], [b2], [b3], [b4], [b5], [c1], [c2], [c3], [c4], [c5]) VALUES (93, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0)
INSERT [dbo].[seat_status] ([schedule_id], [a1], [a2], [a3], [a4], [a5], [b1], [b2], [b3], [b4], [b5], [c1], [c2], [c3], [c4], [c5]) VALUES (94, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0)
INSERT [dbo].[seat_status] ([schedule_id], [a1], [a2], [a3], [a4], [a5], [b1], [b2], [b3], [b4], [b5], [c1], [c2], [c3], [c4], [c5]) VALUES (95, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0)
INSERT [dbo].[seat_status] ([schedule_id], [a1], [a2], [a3], [a4], [a5], [b1], [b2], [b3], [b4], [b5], [c1], [c2], [c3], [c4], [c5]) VALUES (96, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0)
INSERT [dbo].[seat_status] ([schedule_id], [a1], [a2], [a3], [a4], [a5], [b1], [b2], [b3], [b4], [b5], [c1], [c2], [c3], [c4], [c5]) VALUES (97, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0)
INSERT [dbo].[seat_status] ([schedule_id], [a1], [a2], [a3], [a4], [a5], [b1], [b2], [b3], [b4], [b5], [c1], [c2], [c3], [c4], [c5]) VALUES (98, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0)
INSERT [dbo].[seat_status] ([schedule_id], [a1], [a2], [a3], [a4], [a5], [b1], [b2], [b3], [b4], [b5], [c1], [c2], [c3], [c4], [c5]) VALUES (99, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0)
INSERT [dbo].[seat_status] ([schedule_id], [a1], [a2], [a3], [a4], [a5], [b1], [b2], [b3], [b4], [b5], [c1], [c2], [c3], [c4], [c5]) VALUES (100, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0)
GO
SET IDENTITY_INSERT [dbo].[ticket] ON 

INSERT [dbo].[ticket] ([ticket_id], [user_id], [schedule_id], [seat], [adult_num], [elder_num], [child_num], [student_num], [total_price], [order_datetime]) VALUES (2, 1, 14, N'A2,B2', 1, 0, 1, 0, 2800, CAST(N'2023-04-20T00:00:00.000' AS DateTime))
INSERT [dbo].[ticket] ([ticket_id], [user_id], [schedule_id], [seat], [adult_num], [elder_num], [child_num], [student_num], [total_price], [order_datetime]) VALUES (4, 4, 16, N'A4', 1, 0, 0, 0, 1800, CAST(N'2023-04-18T00:00:00.000' AS DateTime))
INSERT [dbo].[ticket] ([ticket_id], [user_id], [schedule_id], [seat], [adult_num], [elder_num], [child_num], [student_num], [total_price], [order_datetime]) VALUES (5, 30, 16, N'A5', 1, 0, 0, 0, 1800, CAST(N'2023-04-18T00:00:00.000' AS DateTime))
INSERT [dbo].[ticket] ([ticket_id], [user_id], [schedule_id], [seat], [adult_num], [elder_num], [child_num], [student_num], [total_price], [order_datetime]) VALUES (7, 26, 14, N'B4,B3', 1, 0, 0, 1, 3100, CAST(N'2023-04-19T00:00:00.000' AS DateTime))
INSERT [dbo].[ticket] ([ticket_id], [user_id], [schedule_id], [seat], [adult_num], [elder_num], [child_num], [student_num], [total_price], [order_datetime]) VALUES (9, 1, 18, N'A3', 1, 0, 0, 0, 1800, CAST(N'2023-04-22T23:58:04.577' AS DateTime))
INSERT [dbo].[ticket] ([ticket_id], [user_id], [schedule_id], [seat], [adult_num], [elder_num], [child_num], [student_num], [total_price], [order_datetime]) VALUES (10, 1, 18, N'A4,B5', 1, 0, 1, 0, 2800, CAST(N'2023-04-22T23:58:17.213' AS DateTime))
INSERT [dbo].[ticket] ([ticket_id], [user_id], [schedule_id], [seat], [adult_num], [elder_num], [child_num], [student_num], [total_price], [order_datetime]) VALUES (11, 4, 75, N'A3,B2', 1, 1, 0, 0, 2900, CAST(N'2023-04-23T01:48:19.427' AS DateTime))
INSERT [dbo].[ticket] ([ticket_id], [user_id], [schedule_id], [seat], [adult_num], [elder_num], [child_num], [student_num], [total_price], [order_datetime]) VALUES (12, 1, 79, N'A5', 1, 0, 0, 0, 1800, CAST(N'2023-04-23T01:58:20.653' AS DateTime))
INSERT [dbo].[ticket] ([ticket_id], [user_id], [schedule_id], [seat], [adult_num], [elder_num], [child_num], [student_num], [total_price], [order_datetime]) VALUES (13, 26, 79, N'A3', 1, 0, 0, 0, 1800, CAST(N'2023-04-23T01:59:23.707' AS DateTime))
INSERT [dbo].[ticket] ([ticket_id], [user_id], [schedule_id], [seat], [adult_num], [elder_num], [child_num], [student_num], [total_price], [order_datetime]) VALUES (14, 26, 79, N'A4', 0, 0, 1, 0, 1000, CAST(N'2023-04-23T01:59:35.763' AS DateTime))
INSERT [dbo].[ticket] ([ticket_id], [user_id], [schedule_id], [seat], [adult_num], [elder_num], [child_num], [student_num], [total_price], [order_datetime]) VALUES (15, 18, 48, N'A3', 1, 0, 0, 0, 1800, CAST(N'2023-04-23T02:00:56.133' AS DateTime))
INSERT [dbo].[ticket] ([ticket_id], [user_id], [schedule_id], [seat], [adult_num], [elder_num], [child_num], [student_num], [total_price], [order_datetime]) VALUES (16, 18, 48, N'B3,C3', 2, 0, 0, 0, 3600, CAST(N'2023-04-23T02:01:32.047' AS DateTime))
INSERT [dbo].[ticket] ([ticket_id], [user_id], [schedule_id], [seat], [adult_num], [elder_num], [child_num], [student_num], [total_price], [order_datetime]) VALUES (17, 27, 78, N'A3', 1, 0, 0, 0, 1800, CAST(N'2023-04-23T02:02:13.560' AS DateTime))
INSERT [dbo].[ticket] ([ticket_id], [user_id], [schedule_id], [seat], [adult_num], [elder_num], [child_num], [student_num], [total_price], [order_datetime]) VALUES (18, 19, 82, N'B3,A3', 1, 0, 1, 0, 2800, CAST(N'2023-04-23T02:03:37.433' AS DateTime))
INSERT [dbo].[ticket] ([ticket_id], [user_id], [schedule_id], [seat], [adult_num], [elder_num], [child_num], [student_num], [total_price], [order_datetime]) VALUES (19, 1, 76, N'A3,B3', 1, 0, 0, 1, 3100, CAST(N'2023-04-23T17:12:39.123' AS DateTime))
INSERT [dbo].[ticket] ([ticket_id], [user_id], [schedule_id], [seat], [adult_num], [elder_num], [child_num], [student_num], [total_price], [order_datetime]) VALUES (20, 1, 42, N'A3,B3', 1, 0, 0, 1, 3100, CAST(N'2023-04-23T17:17:58.463' AS DateTime))
INSERT [dbo].[ticket] ([ticket_id], [user_id], [schedule_id], [seat], [adult_num], [elder_num], [child_num], [student_num], [total_price], [order_datetime]) VALUES (23, 1, 76, N'A3,A4', 2, 0, 0, 0, 3600, CAST(N'2023-04-23T17:38:26.703' AS DateTime))
INSERT [dbo].[ticket] ([ticket_id], [user_id], [schedule_id], [seat], [adult_num], [elder_num], [child_num], [student_num], [total_price], [order_datetime]) VALUES (26, 30, 21, N'A3,A4', 2, 0, 0, 0, 3600, CAST(N'2023-04-23T21:54:49.790' AS DateTime))
INSERT [dbo].[ticket] ([ticket_id], [user_id], [schedule_id], [seat], [adult_num], [elder_num], [child_num], [student_num], [total_price], [order_datetime]) VALUES (27, 23, 42, N'A3,A4', 1, 0, 0, 1, 3100, CAST(N'2023-04-23T21:56:44.393' AS DateTime))
SET IDENTITY_INSERT [dbo].[ticket] OFF
GO
SET IDENTITY_INSERT [dbo].[user] ON 

INSERT [dbo].[user] ([user_id], [role], [user_name], [email], [password], [register_datetime]) VALUES (1, N'admin', N'Ryan Huang', N'ryan@test.com', N'ryan', CAST(N'2023-04-13T00:00:00.000' AS DateTime))
INSERT [dbo].[user] ([user_id], [role], [user_name], [email], [password], [register_datetime]) VALUES (4, N'stf', N'翔太', N'syouta@test.com', N'syouta', CAST(N'2023-04-15T00:00:00.000' AS DateTime))
INSERT [dbo].[user] ([user_id], [role], [user_name], [email], [password], [register_datetime]) VALUES (9, N'mb', N'由美子', N'yumiko@test.com', N'yumiko', CAST(N'2023-04-20T09:15:00.000' AS DateTime))
INSERT [dbo].[user] ([user_id], [role], [user_name], [email], [password], [register_datetime]) VALUES (10, N'mb', N'奈美恵', N'namie@test.com', N'namie', CAST(N'2023-04-16T13:20:36.000' AS DateTime))
INSERT [dbo].[user] ([user_id], [role], [user_name], [email], [password], [register_datetime]) VALUES (13, N'stf', N'拓也', N'takuta@test.com', N'takuya', CAST(N'2023-04-15T18:23:30.000' AS DateTime))
INSERT [dbo].[user] ([user_id], [role], [user_name], [email], [password], [register_datetime]) VALUES (18, N'mb', N'涼平', N'ryouhei@test.com', N'ryouhei', CAST(N'2023-04-23T08:20:33.000' AS DateTime))
INSERT [dbo].[user] ([user_id], [role], [user_name], [email], [password], [register_datetime]) VALUES (19, N'stf', N'咲良', N'sakura@test.com', N'sakura', CAST(N'2023-04-16T15:43:00.000' AS DateTime))
INSERT [dbo].[user] ([user_id], [role], [user_name], [email], [password], [register_datetime]) VALUES (20, N'mb', N'真央', N'mao@test.com', N'mao', CAST(N'2023-04-24T01:22:03.000' AS DateTime))
INSERT [dbo].[user] ([user_id], [role], [user_name], [email], [password], [register_datetime]) VALUES (23, N'mb', N'瑛太', N'eita@test.com', N'eita', CAST(N'2023-04-23T02:22:33.000' AS DateTime))
INSERT [dbo].[user] ([user_id], [role], [user_name], [email], [password], [register_datetime]) VALUES (25, N'stf', N'涼介', N'ryousuke@test.com', N'ryousuke', CAST(N'2023-04-15T18:49:15.137' AS DateTime))
INSERT [dbo].[user] ([user_id], [role], [user_name], [email], [password], [register_datetime]) VALUES (26, N'mb', N'健太郎', N'kentaro@test.com', N'kentaro', CAST(N'2023-04-15T02:30:00.000' AS DateTime))
INSERT [dbo].[user] ([user_id], [role], [user_name], [email], [password], [register_datetime]) VALUES (27, N'mb', N'悠人', N'yuuto@test.com', N'yuuto', CAST(N'2023-04-20T01:53:12.000' AS DateTime))
INSERT [dbo].[user] ([user_id], [role], [user_name], [email], [password], [register_datetime]) VALUES (30, N'mb', N'美希', N'miki@test.com', N'miki', CAST(N'2023-04-17T21:52:00.187' AS DateTime))
INSERT [dbo].[user] ([user_id], [role], [user_name], [email], [password], [register_datetime]) VALUES (32, N'mb', N'将暉', N'masaki@test.com', N'masaki', CAST(N'2023-04-23T17:07:23.060' AS DateTime))
INSERT [dbo].[user] ([user_id], [role], [user_name], [email], [password], [register_datetime]) VALUES (33, N'mb', N'蒼汰', N'souta@test.com', N'souta', CAST(N'2023-04-23T22:55:40.340' AS DateTime))
SET IDENTITY_INSERT [dbo].[user] OFF
GO
ALTER TABLE [dbo].[schedule]  WITH CHECK ADD  CONSTRAINT [FK_schedule_hall] FOREIGN KEY([hall_id])
REFERENCES [dbo].[hall] ([hall_id])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[schedule] CHECK CONSTRAINT [FK_schedule_hall]
GO
ALTER TABLE [dbo].[schedule]  WITH CHECK ADD  CONSTRAINT [FK_schedule_movie] FOREIGN KEY([movie_id])
REFERENCES [dbo].[movie] ([movie_id])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[schedule] CHECK CONSTRAINT [FK_schedule_movie]
GO
ALTER TABLE [dbo].[seat_status]  WITH CHECK ADD  CONSTRAINT [FK_seat_status_schedule] FOREIGN KEY([schedule_id])
REFERENCES [dbo].[schedule] ([schedule_id])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[seat_status] CHECK CONSTRAINT [FK_seat_status_schedule]
GO
ALTER TABLE [dbo].[ticket]  WITH CHECK ADD  CONSTRAINT [FK_ticket_schedule] FOREIGN KEY([schedule_id])
REFERENCES [dbo].[schedule] ([schedule_id])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[ticket] CHECK CONSTRAINT [FK_ticket_schedule]
GO
ALTER TABLE [dbo].[ticket]  WITH CHECK ADD  CONSTRAINT [FK_ticket_user] FOREIGN KEY([user_id])
REFERENCES [dbo].[user] ([user_id])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[ticket] CHECK CONSTRAINT [FK_ticket_user]
GO
USE [master]
GO
ALTER DATABASE [MovieTheaterManagement] SET  READ_WRITE 
GO
