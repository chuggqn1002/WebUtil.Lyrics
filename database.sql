create database wulyrics;
use wulyrics;
create table albums(
	albumid int auto_increment primary key,
	albumcode varchar(30),
    albumname varchar(255),
    released DateTime,
    status tinyint
);
create table authors(
	authorid int auto_increment primary key,
    authorcode varchar(30),
    authorname varchar(255),
    bio text,
    avatar varchar(255),
    status tinyint
);
create table singers(
	singerid int auto_increment primary key,
    singercode varchar(30),
    singername varchar(255),
    bio text,
    avatar varchar(255),
    status tinyint
);
create table songs(
	sid int auto_increment primary key,
    suid varchar(36),
    songcode varchar(30),
    title varchar(255),
    author varchar(30),
    album  varchar(30),
    singer  varchar(30),
    imgurl varchar(255),
    ytbcode varchar(50),
    videolink  varchar(255),
    description varchar(255),
    released datetime,
    status tinyint
);
create table song_lines(
	slid int auto_increment primary key,
    suid varchar(36),
    song_text varchar(255),
    line_order int,
    para tinyint
);
create table users(
	userid int auto_increment primary key,
    uuid varchar(36),
    username varchar(255),
    email varchar(255),
    password varchar(255),
    role int,
    status tinyint,
    created timestamp,
    updated timestamp
);
create table user_songs(
	usid int auto_increment primary key,
    uuid varchar(36),
    songcode varchar(30),
    fav tinyint,
    created datetime
);
create table song_tags(
	stid int auto_increment primary key,
    suid varchar(36),
    tagcode varchar(30),
    status tinyint
);
create table tags(
	tagid int auto_increment primary key,
    tagcode varchar(30),
    tagname varchar(255),
    status tinyint
);
create table user_profiles(
	profileid int auto_increment primary key,
    uuid varchar(36),
    firstname varchar(50),
    lastname varchar(50),
    middle varchar(50),
    title varchar(20),
    address varchar(255),
    ward varchar(50),
    district varchar(50),
    city varchar(35),
    country varchar(35),
    birthday datetime,
    avatar varchar(255),
    gender tinyint,
    telnum varchar(20),
    description tinytext,
    status tinyint,
    zipcode char(10),
    created datetime,
    updated datetime
);
create table categories(
	categoryid int auto_increment primary key,
    categorycode varchar(30),
    categoryname varchar(255),
    status tinyint
);
create table song_categories(
	scid int auto_increment primary key,
    suid varchar(36),
    categorycode varchar(30),
    status tinyint
);

use wulyrics;
select * from users;
SELECT u.* FROM users u WHERE u.email = "admin@gmail.com"
select * from user_profiles;
INSERT INTO `wulyrics`.`songs`(`suid`,`songcode`,`title`,`author`,`album`,`singer`,`imgurl`,`ytbcode`,`videolink`,`description`,`released`,`status`) VALUES('80feea0c-5619-11ee-b330-309c23138cba','bai-ca-thong-nhat-trong-tan','Bài Ca Thống Nhất','Mot_rung_cay_mot_doi_nguoi','Tran Long An','trong-tan','https://img.bcdcnt.net/files/77/d1/15/77d11543155575596c9f849268c7f7b7.jpg','WB7wxGidxPs','https://www.youtube.com/watch?v=WB7wxGidxPs','Biển trời bao la Đẹp như gấm hoa Nước mây muôn màu Những con tàu ra Bắc vào Nam Biển trời quê ta Rộn vang tiếng ca Bắc Nam một','2023-09-18 18:49:52','1');

Insert into user_profiles (Uuid, FirstName,LastName,Middle,Title,Address,Ward,District,City,Country,ZipCode,Birthdate,Avatar,Gender,TelNum,Description,Status,Created,Updated) VALUES ("8bcf0da4-d4ff-4ff1-8632-bce7dfa7fced", "fewfewf","fewfe","string","string","string","string","string","string","string","2023-10-13T15:34:09.772Z","string",0,"string","string",0,"2023-10-13T15:34:09.772Z","2023-10-13T15:34:09.772Z");
insert into tags(tagid, tagcode, tagname, status) values ('1','bai-ca-thong-nhat','Bài Ca Thống Nhất','1');insert into tags(tagid, tagcode, tagname, status) values ('2','nhac-cach-mang','Nhạc Cách Mạng','1');insert into tags(tagid, tagcode, tagname, status) values ('3','trong-tan','Trọng Tấn','1');insert into tags(tagid, tagcode, tagname, status) values ('4','viet-nam','Việt Nam','1');
select * from tags;
select * from authors;
INSERT INTO `wulyrics`.`song_lines` (`slid`, `suid`, `song_text`, `line_order`, `para`) VALUES('1','80feea0c-5619-11ee-b330-309c23138cba','Biển trời bao la','1','0');INSERT INTO `wulyrics`.`song_lines` (`slid`, `suid`, `song_text`, `line_order`, `para`) VALUES('2','80feea0c-5619-11ee-b330-309c23138cba','Đẹp như gấm hoa','2','0');INSERT INTO `wulyrics`.`song_lines` (`slid`, `suid`, `song_text`, `line_order`, `para`) VALUES('3','80feea0c-5619-11ee-b330-309c23138cba','Nước mây muôn màu','3','0');INSERT INTO `wulyrics`.`song_lines` (`slid`, `suid`, `song_text`, `line_order`, `para`) VALUES('4','80feea0c-5619-11ee-b330-309c23138cba','Những con tàu ra Bắc vào Nam','4','0');INSERT INTO `wulyrics`.`song_lines` (`slid`, `suid`, `song_text`, `line_order`, `para`) VALUES('5','80feea0c-5619-11ee-b330-309c23138cba','Biển trời quê ta','5','0');INSERT INTO `wulyrics`.`song_lines` (`slid`, `suid`, `song_text`, `line_order`, `para`) VALUES('6','80feea0c-5619-11ee-b330-309c23138cba','Rộn vang tiếng ca','6','0');INSERT INTO `wulyrics`.`song_lines` (`slid`, `suid`, `song_text`, `line_order`, `para`) VALUES('7','80feea0c-5619-11ee-b330-309c23138cba','Bắc Nam một nhà','7','0');INSERT INTO `wulyrics`.`song_lines` (`slid`, `suid`, `song_text`, `line_order`, `para`) VALUES('8','80feea0c-5619-11ee-b330-309c23138cba','Vui một nhà vang tiếng hò khoan','8','0');INSERT INTO `wulyrics`.`song_lines` (`slid`, `suid`, `song_text`, `line_order`, `para`) VALUES('9','80feea0c-5619-11ee-b330-309c23138cba','Dô&#8230; khoan','9','0');INSERT INTO `wulyrics`.`song_lines` (`slid`, `suid`, `song_text`, `line_order`, `para`) VALUES('10','80feea0c-5619-11ee-b330-309c23138cba','Là khoan dô hò','10','0');INSERT INTO `wulyrics`.`song_lines` (`slid`, `suid`, `song_text`, `line_order`, `para`) VALUES('11','80feea0c-5619-11ee-b330-309c23138cba','Là khoan dô khoan','11','0');INSERT INTO `wulyrics`.`song_lines` (`slid`, `suid`, `song_text`, `line_order`, `para`) VALUES('12','80feea0c-5619-11ee-b330-309c23138cba','Trời tỏa nắng nắng lan núi ngàn','12','0');INSERT INTO `wulyrics`.`song_lines` (`slid`, `suid`, `song_text`, `line_order`, `para`) VALUES('13','80feea0c-5619-11ee-b330-309c23138cba','Một mùa Đông gió Bắc vừa tan','13','0');INSERT INTO `wulyrics`.`song_lines` (`slid`, `suid`, `song_text`, `line_order`, `para`) VALUES('14','80feea0c-5619-11ee-b330-309c23138cba','Bạn mình ơi đón vui Xuân về','14','0');INSERT INTO `wulyrics`.`song_lines` (`slid`, `suid`, `song_text`, `line_order`, `para`) VALUES('15','80feea0c-5619-11ee-b330-309c23138cba','Hân hoan&#8230;','15','0');INSERT INTO `wulyrics`.`song_lines` (`slid`, `suid`, `song_text`, `line_order`, `para`) VALUES('16','80feea0c-5619-11ee-b330-309c23138cba','Biển trời Xuân sang','16','0');INSERT INTO `wulyrics`.`song_lines` (`slid`, `suid`, `song_text`, `line_order`, `para`) VALUES('17','80feea0c-5619-11ee-b330-309c23138cba','Bắc Nam sum họp','17','0');INSERT INTO `wulyrics`.`song_lines` (`slid`, `suid`, `song_text`, `line_order`, `para`) VALUES('18','80feea0c-5619-11ee-b330-309c23138cba','Một nhà đông vui','18','0');INSERT INTO `wulyrics`.`song_lines` (`slid`, `suid`, `song_text`, `line_order`, `para`) VALUES('19','80feea0c-5619-11ee-b330-309c23138cba','Huy hoàng&#8230;','19','0');INSERT INTO `wulyrics`.`song_lines` (`slid`, `suid`, `song_text`, `line_order`, `para`) VALUES('20','80feea0c-5619-11ee-b330-309c23138cba','Biển trời Xuân sang','20','0');INSERT INTO `wulyrics`.`song_lines` (`slid`, `suid`, `song_text`, `line_order`, `para`) VALUES('21','80feea0c-5619-11ee-b330-309c23138cba','Con chim reo mừng','21','0');INSERT INTO `wulyrics`.`song_lines` (`slid`, `suid`, `song_text`, `line_order`, `para`) VALUES('22','80feea0c-5619-11ee-b330-309c23138cba','Trở về quê hương','22','0');INSERT INTO `wulyrics`.`song_lines` (`slid`, `suid`, `song_text`, `line_order`, `para`) VALUES('23','80feea0c-5619-11ee-b330-309c23138cba','Mến thương&#8230;','23','0');INSERT INTO `wulyrics`.`song_lines` (`slid`, `suid`, `song_text`, `line_order`, `para`) VALUES('24','80feea0c-5619-11ee-b330-309c23138cba','Ôi&#8230;','24','0');INSERT INTO `wulyrics`.`song_lines` (`slid`, `suid`, `song_text`, `line_order`, `para`) VALUES('25','80feea0c-5619-11ee-b330-309c23138cba','Khải hoàn ta ra','25','0');INSERT INTO `wulyrics`.`song_lines` (`slid`, `suid`, `song_text`, `line_order`, `para`) VALUES('26','80feea0c-5619-11ee-b330-309c23138cba','Ta gạt mái chèo','26','0');INSERT INTO `wulyrics`.`song_lines` (`slid`, `suid`, `song_text`, `line_order`, `para`) VALUES('27','80feea0c-5619-11ee-b330-309c23138cba','Tự do ra khơi','27','0');INSERT INTO `wulyrics`.`song_lines` (`slid`, `suid`, `song_text`, `line_order`, `para`) VALUES('28','80feea0c-5619-11ee-b330-309c23138cba','Tự do vô lộng','28','0');INSERT INTO `wulyrics`.`song_lines` (`slid`, `suid`, `song_text`, `line_order`, `para`) VALUES('29','80feea0c-5619-11ee-b330-309c23138cba','Đời tự do','29','0');INSERT INTO `wulyrics`.`song_lines` (`slid`, `suid`, `song_text`, `line_order`, `para`) VALUES('30','80feea0c-5619-11ee-b330-309c23138cba','Gió Xuân về','30','0');INSERT INTO `wulyrics`.`song_lines` (`slid`, `suid`, `song_text`, `line_order`, `para`) VALUES('31','80feea0c-5619-11ee-b330-309c23138cba','Đời tự do','31','0');INSERT INTO `wulyrics`.`song_lines` (`slid`, `suid`, `song_text`, `line_order`, `para`) VALUES('32','80feea0c-5619-11ee-b330-309c23138cba','Gió Xuân về.','32','0');INSERT INTO `wulyrics`.`song_lines` (`slid`, `suid`, `song_text`, `line_order`, `para`) VALUES('33','80feea0c-5619-11ee-b330-309c23138cba','Dô&#8230; khoan','33','0');INSERT INTO `wulyrics`.`song_lines` (`slid`, `suid`, `song_text`, `line_order`, `para`) VALUES('34','80feea0c-5619-11ee-b330-309c23138cba','Là khoan dô hò','34','0');INSERT INTO `wulyrics`.`song_lines` (`slid`, `suid`, `song_text`, `line_order`, `para`) VALUES('35','80feea0c-5619-11ee-b330-309c23138cba','Là khoan dô khoan','35','0');INSERT INTO `wulyrics`.`song_lines` (`slid`, `suid`, `song_text`, `line_order`, `para`) VALUES('36','80feea0c-5619-11ee-b330-309c23138cba','Trời Việt Nam gió reo nắng cười','36','0');INSERT INTO `wulyrics`.`song_lines` (`slid`, `suid`, `song_text`, `line_order`, `para`) VALUES('37','80feea0c-5619-11ee-b330-309c23138cba','Đàn bồ câu tắm trong vàng tươi','37','0');INSERT INTO `wulyrics`.`song_lines` (`slid`, `suid`, `song_text`, `line_order`, `para`) VALUES('38','80feea0c-5619-11ee-b330-309c23138cba','Người Việt Nam đón Xuân xây đời','38','0');INSERT INTO `wulyrics`.`song_lines` (`slid`, `suid`, `song_text`, `line_order`, `para`) VALUES('39','80feea0c-5619-11ee-b330-309c23138cba','Tương lai&#8230;','39','0');INSERT INTO `wulyrics`.`song_lines` (`slid`, `suid`, `song_text`, `line_order`, `para`) VALUES('40','80feea0c-5619-11ee-b330-309c23138cba','Biển trời quê ta','40','0');INSERT INTO `wulyrics`.`song_lines` (`slid`, `suid`, `song_text`, `line_order`, `para`) VALUES('41','80feea0c-5619-11ee-b330-309c23138cba','Bao năm chia rời','41','0');INSERT INTO `wulyrics`.`song_lines` (`slid`, `suid`, `song_text`, `line_order`, `para`) VALUES('42','80feea0c-5619-11ee-b330-309c23138cba','Cuộc đời chia đôi','42','0');INSERT INTO `wulyrics`.`song_lines` (`slid`, `suid`, `song_text`, `line_order`, `para`) VALUES('43','80feea0c-5619-11ee-b330-309c23138cba','Nơi phương trời&#8230;','43','0');INSERT INTO `wulyrics`.`song_lines` (`slid`, `suid`, `song_text`, `line_order`, `para`) VALUES('44','80feea0c-5619-11ee-b330-309c23138cba','Biển trời quê ta','44','0');INSERT INTO `wulyrics`.`song_lines` (`slid`, `suid`, `song_text`, `line_order`, `para`) VALUES('45','80feea0c-5619-11ee-b330-309c23138cba','Nay chung một nhà','45','0');INSERT INTO `wulyrics`.`song_lines` (`slid`, `suid`, `song_text`, `line_order`, `para`) VALUES('46','80feea0c-5619-11ee-b330-309c23138cba','Thỏa lòng bao năm','46','0');INSERT INTO `wulyrics`.`song_lines` (`slid`, `suid`, `song_text`, `line_order`, `para`) VALUES('47','80feea0c-5619-11ee-b330-309c23138cba','Ước mơ&#8230;','47','0');INSERT INTO `wulyrics`.`song_lines` (`slid`, `suid`, `song_text`, `line_order`, `para`) VALUES('48','80feea0c-5619-11ee-b330-309c23138cba','Ôi&#8230;','48','0');INSERT INTO `wulyrics`.`song_lines` (`slid`, `suid`, `song_text`, `line_order`, `para`) VALUES('49','80feea0c-5619-11ee-b330-309c23138cba','Biển trời bao la','49','0');INSERT INTO `wulyrics`.`song_lines` (`slid`, `suid`, `song_text`, `line_order`, `para`) VALUES('50','80feea0c-5619-11ee-b330-309c23138cba','Đã sạch bóng thù','50','0');INSERT INTO `wulyrics`.`song_lines` (`slid`, `suid`, `song_text`, `line_order`, `para`) VALUES('51','80feea0c-5619-11ee-b330-309c23138cba','Từ Bắc vô Nam','51','0');INSERT INTO `wulyrics`.`song_lines` (`slid`, `suid`, `song_text`, `line_order`, `para`) VALUES('52','80feea0c-5619-11ee-b330-309c23138cba','Cờ sao tưng bừng','52','0');INSERT INTO `wulyrics`.`song_lines` (`slid`, `suid`, `song_text`, `line_order`, `para`) VALUES('53','80feea0c-5619-11ee-b330-309c23138cba','Người Việt Nam','53','0');INSERT INTO `wulyrics`.`song_lines` (`slid`, `suid`, `song_text`, `line_order`, `para`) VALUES('54','80feea0c-5619-11ee-b330-309c23138cba','Đón Xuân về','54','0');INSERT INTO `wulyrics`.`song_lines` (`slid`, `suid`, `song_text`, `line_order`, `para`) VALUES('55','80feea0c-5619-11ee-b330-309c23138cba','Người Việt Nam','55','0');INSERT INTO `wulyrics`.`song_lines` (`slid`, `suid`, `song_text`, `line_order`, `para`) VALUES('56','80feea0c-5619-11ee-b330-309c23138cba','Đón Xuân về','56','0');INSERT INTO `wulyrics`.`song_lines` (`slid`, `suid`, `song_text`, `line_order`, `para`) VALUES('57','80feea0c-5619-11ee-b330-309c23138cba','Người Việt Nam','57','0');INSERT INTO `wulyrics`.`song_lines` (`slid`, `suid`, `song_text`, `line_order`, `para`) VALUES('58','80feea0c-5619-11ee-b330-309c23138cba','Đón Xuân về.','58','0');
select * from song_lines;
 SELECT s.*,a.AuthorCode,  a.AuthorName,  al.AlbumName, al.AlbumCode, si.SingerCode, si.SingerName  FROM songs s  JOIN  authors a ON s.author = a.authorcode   JOIN  albums al ON s.album = al.albumcode  JOIN  singers si ON s.singer = si.singercode  WHERE s.Suid = "80feea0c-5619-11ee-b330-309c23138cba";
INSERT INTO `wulyrics`.`song_tags` (`stid`, `suid`, `tagcode`, `status`) VALUES('1','80feea0c-5619-11ee-b330-309c23138cba','bai-ca-thong-nhat','1');INSERT INTO `wulyrics`.`song_tags` (`stid`, `suid`, `tagcode`, `status`) VALUES('2','80feea0c-5619-11ee-b330-309c23138cba','nhac-cach-mang','1');INSERT INTO `wulyrics`.`song_tags` (`stid`, `suid`, `tagcode`, `status`) VALUES('3','80feea0c-5619-11ee-b330-309c23138cba','trong-tan','1');INSERT INTO `wulyrics`.`song_tags` (`stid`, `suid`, `tagcode`, `status`) VALUES('4','80feea0c-5619-11ee-b330-309c23138cba','viet-nam','1');
select * from song_tags;
select * from song_tags st inner join tags t on st.tagcode = t.tagcode where st.suid = "80feea0c-5619-11ee-b330-309c23138cba";

select * from Categories;
select * from song_Categories;
select * from song_categories sc inner join categories c on sc.categorycode = c.categorycode where sc.suid = "80feea0c-5619-11ee-b330-309c23138cba";
 SELECT s.*,  a.AuthorName,  al.AlbumName, si.SingerName  FROM songs s  JOIN  authors a ON s.author = a.authorcode   JOIN  albums al ON s.album = al.albumcode  JOIN  singers si ON s.singer = si.singercode  WHERE s.Suid = "80feea0c-5619-11ee-b330-309c23138cba";
select * from songs;
insert into albums(albumcode, albumname, released,status) values("Tran Long An","Tran Long An","2022-10-10",1);
insert into authors(authorcode, authorname, bio,avatar,status) values("Mot_rung_cay_mot_doi_nguoi","Motrungcaymotdoinguoi","htrhjtyjty","",1);
insert into singers(singercode, singername, bio,avatar,status) values("trong-tan","Trong Tan","htrhjtyjty","",1);

select * from albums;

