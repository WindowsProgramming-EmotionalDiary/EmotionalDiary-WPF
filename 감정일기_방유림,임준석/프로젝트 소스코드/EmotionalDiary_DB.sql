-- --------------------------------------------------------
-- 호스트:                          127.0.0.1
-- 서버 버전:                        11.3.2-MariaDB - mariadb.org binary distribution
-- 서버 OS:                        Win64
-- HeidiSQL 버전:                  12.7.0.6850
-- --------------------------------------------------------

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET NAMES utf8 */;
/*!50503 SET NAMES utf8mb4 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;


-- database 데이터베이스 구조 내보내기
CREATE DATABASE IF NOT EXISTS `database` /*!40100 DEFAULT CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci */;
USE `database`;

-- 테이블 database.community 구조 내보내기
CREATE TABLE IF NOT EXISTS `community` (
  `pk` bigint(20) NOT NULL AUTO_INCREMENT,
  `date` datetime NOT NULL,
  `diary_pk` bigint(20) NOT NULL DEFAULT 0,
  PRIMARY KEY (`pk`),
  KEY `FK__diary` (`diary_pk`),
  CONSTRAINT `FK__diary` FOREIGN KEY (`diary_pk`) REFERENCES `diary` (`pk`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB AUTO_INCREMENT=14 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- 내보낼 데이터가 선택되어 있지 않습니다.

-- 테이블 database.diary 구조 내보내기
CREATE TABLE IF NOT EXISTS `diary` (
  `pk` bigint(20) NOT NULL AUTO_INCREMENT,
  `title` varchar(255) NOT NULL DEFAULT 'title',
  `content` varchar(255) NOT NULL DEFAULT 'content',
  `emotion` varchar(2) NOT NULL DEFAULT '행복',
  `like_cnt` int(11) NOT NULL DEFAULT 0,
  `user_pk` bigint(20) NOT NULL DEFAULT 0,
  PRIMARY KEY (`pk`),
  KEY `fk` (`user_pk`),
  CONSTRAINT `fk` FOREIGN KEY (`user_pk`) REFERENCES `user` (`pk`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB AUTO_INCREMENT=15 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- 내보낼 데이터가 선택되어 있지 않습니다.

-- 테이블 database.to_do_list 구조 내보내기
CREATE TABLE IF NOT EXISTS `to_do_list` (
  `pk` bigint(20) NOT NULL AUTO_INCREMENT,
  `date` varchar(50) DEFAULT NULL,
  `to_do1` varchar(255) DEFAULT NULL,
  `user_pk` bigint(20) NOT NULL,
  `to_do2` varchar(255) DEFAULT NULL,
  `to_do3` varchar(255) DEFAULT NULL,
  `to_do4` varchar(255) DEFAULT NULL,
  `to_do5` varchar(255) DEFAULT NULL,
  `CHECK1` tinyint(1) DEFAULT NULL,
  `CHECK2` tinyint(1) DEFAULT NULL,
  `CHECK3` tinyint(1) DEFAULT NULL,
  `CHECK4` tinyint(1) DEFAULT NULL,
  `CHECK5` tinyint(1) DEFAULT NULL,
  PRIMARY KEY (`pk`),
  KEY `user_pk` (`user_pk`),
  CONSTRAINT `user_pk` FOREIGN KEY (`user_pk`) REFERENCES `user` (`pk`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB AUTO_INCREMENT=38 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- 내보낼 데이터가 선택되어 있지 않습니다.

-- 테이블 database.user 구조 내보내기
CREATE TABLE IF NOT EXISTS `user` (
  `pk` bigint(20) NOT NULL AUTO_INCREMENT,
  `create_at` datetime DEFAULT NULL,
  `name` varchar(255) NOT NULL DEFAULT '김뫄뫄',
  `phone_num` varchar(11) NOT NULL DEFAULT '01000000000',
  `birth` varchar(8) NOT NULL DEFAULT '19600101',
  `address` varchar(255) NOT NULL DEFAULT '경북 구미시',
  `sex` varchar(2) NOT NULL DEFAULT '여성',
  PRIMARY KEY (`pk`)
) ENGINE=InnoDB AUTO_INCREMENT=8 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- 내보낼 데이터가 선택되어 있지 않습니다.

/*!40103 SET TIME_ZONE=IFNULL(@OLD_TIME_ZONE, 'system') */;
/*!40101 SET SQL_MODE=IFNULL(@OLD_SQL_MODE, '') */;
/*!40014 SET FOREIGN_KEY_CHECKS=IFNULL(@OLD_FOREIGN_KEY_CHECKS, 1) */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40111 SET SQL_NOTES=IFNULL(@OLD_SQL_NOTES, 1) */;
