-- Se busca con el codigo del socio TODO su historial de prestamos --
CREATE PROC HistorialSocio @CodigoSocio int
AS
  SELECT
    Prestamo.CodigoPrestamo,
    Catalogo.Titulo,
    Prestamo.Estado,
    Prestamo.FechaPrestamo
  FROM [Socio.Prestamo] AS Prestamo
  LEFT JOIN [Socio.Informacion] AS Socio
    ON Socio.CodigoSocio = Prestamo.CodigoSocio
  LEFT JOIN [Libreria.Catalogo] AS Catalogo
    ON Catalogo.CodigoLibro = Prestamo.CodigoLibro
  WHERE Prestamo.CodigoSocio = @CodigoSocio