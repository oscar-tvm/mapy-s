-- phpMyAdmin SQL Dump
-- version 5.0.4
-- https://www.phpmyadmin.net/
--
-- Servidor: 127.0.0.1
-- Tiempo de generación: 25-04-2023 a las 00:57:48
-- Versión del servidor: 10.4.17-MariaDB
-- Versión de PHP: 8.0.1

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Base de datos: `mapys`
--

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `categorias`
--

CREATE TABLE `categorias` (
  `codigo` int(11) NOT NULL,
  `nombre` varchar(20) DEFAULT NULL,
  `href` varchar(250) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Volcado de datos para la tabla `categorias`
--

INSERT INTO `categorias` (`codigo`, `nombre`, `href`) VALUES
(1, 'Aretes', 'Aretes'),
(2, 'Collares', 'Collares'),
(3, 'Tobilleras', 'Tobilleras'),
(4, 'Pulseras', 'Pulseras');

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `clientes`
--

CREATE TABLE `clientes` (
  `cc` int(11) NOT NULL,
  `pri_nombre` varchar(25) NOT NULL,
  `pri_apellido` varchar(15) DEFAULT NULL,
  `seg_apellido` varchar(20) DEFAULT NULL,
  `direccion` varchar(30) DEFAULT NULL,
  `telefono_movil` varchar(10) NOT NULL,
  `ciudad` varchar(20) DEFAULT NULL,
  `email` varchar(45) NOT NULL,
  `ROL_codigo` int(11) DEFAULT NULL,
  `password` varchar(250) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Volcado de datos para la tabla `clientes`
--

INSERT INTO `clientes` (`cc`, `pri_nombre`, `pri_apellido`, `seg_apellido`, `direccion`, `telefono_movil`, `ciudad`, `email`, `ROL_codigo`, `password`) VALUES
(100, 'Pedro Andres', 'Villanueva', 'Delgado', 'Cra 24 #12 - 23', '3102884444', 'Neiva', 'camilo@hotmail.com', 1, '1234'),
(2020, 'Felipe Andres', 'Ortiz', 'Pastrana', 'Cra 10 # 21- 50', '3232232', 'Bogota', 'camilo@hotmail.com', 2, '1234'),
(1077875566, 'Cristian', 'Segura', 'vill', 'cra', '7832', 'Neiva', 'maria@gmail.com', 1, '1234');

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `mensaje_cliente`
--

CREATE TABLE `mensaje_cliente` (
  `id` int(11) NOT NULL,
  `nombre` varchar(50) NOT NULL,
  `email` varchar(50) NOT NULL,
  `telefono` varchar(20) NOT NULL,
  `ciudad` varchar(30) NOT NULL,
  `mensaje` text NOT NULL,
  `created_at` timestamp NULL DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Volcado de datos para la tabla `mensaje_cliente`
--

INSERT INTO `mensaje_cliente` (`id`, `nombre`, `email`, `telefono`, `ciudad`, `mensaje`, `created_at`) VALUES
(1, 'cris', 'pepe@gmail.com', '432879', 'Neiva', 'prueba', '2023-04-24 22:33:13');

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `productos`
--

CREATE TABLE `productos` (
  `codigo` int(11) NOT NULL,
  `nombre` varchar(35) DEFAULT NULL,
  `precio` varchar(25) DEFAULT NULL,
  `CATEGORIAS_codigo` int(11) DEFAULT NULL,
  `imagen` varchar(250) DEFAULT NULL,
  `fecha` date DEFAULT NULL,
  `descuento` int(10) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Volcado de datos para la tabla `productos`
--

INSERT INTO `productos` (`codigo`, `nombre`, `precio`, `CATEGORIAS_codigo`, `imagen`, `fecha`, `descuento`) VALUES
(1, 'Hoja woven', '35000', 1, 'arete1.jpg', '2020-06-08', 8),
(2, 'Arete  whirlwind', '30000', 1, 'arete2.jpg', '2020-06-08', 0),
(3, 'Arete Jadenes', '26000', 1, 'arete3.jpg', '2020-06-08', 0),
(4, 'Arete Hadara', '26000', 1, 'arete4.jpg', '2020-06-08', 0),
(5, 'Mano Hamsa ', '35000', 2, 'collar1.jpg', '2020-06-08', 20),
(6, '\"Bella\" ', '22000', 2, 'collar2.jpg', '2020-06-08', 0),
(7, ' dragon-fly diamond', '28000 ', 2, 'collar3.jpg', '2020-06-08', 10),
(8, 'Pulsera Mythica', '20000', 4, 'pulseras1.jpg', '2020-06-08', 0),
(9, 'Pulsera Zanati', '22000', 4, 'pulseras2.jpg', '2020-06-08', 5),
(10, 'Pulsera dorada punto de rosa', '22000', 4, 'pulseras3.jpg', '2020-06-08', 5),
(11, 'Pulsera de perlas', '33999', 4, 'pulseras4.jpg', '2020-06-08', 0),
(12, 'Tobillera de dados', '25000', 3, 'tobillera1.jpg', '2020-06-08', 2),
(13, 'Tobillera de Cruz', '24099', 3, 'tobillera2.jpg', '2020-06-08', 2),
(14, 'Tobillera Dark', '15999', 3, 'tobillera3.jpg', '2020-06-08', 0),
(15, 'Tobillera Huesos ', '12999', 3, 'tobillera5.jpg', '2020-06-08', 0),
(17, 'Tobillera Games', '9090', 3, 'tobillera2.jpg', '2023-04-26', 10);

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `roles`
--

CREATE TABLE `roles` (
  `codigo` int(11) NOT NULL,
  `nombre` varchar(15) NOT NULL,
  `descripcion` varchar(45) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Volcado de datos para la tabla `roles`
--

INSERT INTO `roles` (`codigo`, `nombre`, `descripcion`) VALUES
(1, 'Admin', 'Global'),
(2, 'Sin permiso', 'Hasta que sea asignado a Admin puede ingresar');

--
-- Índices para tablas volcadas
--

--
-- Indices de la tabla `categorias`
--
ALTER TABLE `categorias`
  ADD PRIMARY KEY (`codigo`);

--
-- Indices de la tabla `clientes`
--
ALTER TABLE `clientes`
  ADD PRIMARY KEY (`cc`),
  ADD KEY `fk_ROL_codigo` (`ROL_codigo`);

--
-- Indices de la tabla `mensaje_cliente`
--
ALTER TABLE `mensaje_cliente`
  ADD PRIMARY KEY (`id`);

--
-- Indices de la tabla `productos`
--
ALTER TABLE `productos`
  ADD PRIMARY KEY (`codigo`),
  ADD KEY `fk_CATEGORIAS_codigo` (`CATEGORIAS_codigo`);

--
-- Indices de la tabla `roles`
--
ALTER TABLE `roles`
  ADD PRIMARY KEY (`codigo`);

--
-- AUTO_INCREMENT de las tablas volcadas
--

--
-- AUTO_INCREMENT de la tabla `mensaje_cliente`
--
ALTER TABLE `mensaje_cliente`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=2;

--
-- AUTO_INCREMENT de la tabla `productos`
--
ALTER TABLE `productos`
  MODIFY `codigo` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=19;

--
-- Restricciones para tablas volcadas
--

--
-- Filtros para la tabla `clientes`
--
ALTER TABLE `clientes`
  ADD CONSTRAINT `fk_ROL_codigo` FOREIGN KEY (`ROL_codigo`) REFERENCES `roles` (`codigo`);

--
-- Filtros para la tabla `productos`
--
ALTER TABLE `productos`
  ADD CONSTRAINT `fk_CATEGORIAS_codigo` FOREIGN KEY (`CATEGORIAS_codigo`) REFERENCES `categorias` (`codigo`);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
