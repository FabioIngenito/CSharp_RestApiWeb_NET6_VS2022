// Baseado e bastante modificado do Exemplo:
//
// MINIMAL APIs COM SQL ( .NET6 C# ) VISUAL STUDIO 2022
// 11 de nov. de 2021 - Tempo de v�deo: 34:01
// DEV NET CORE Valdir Ferreira
// https://youtu.be/_vzTewWNI4k
//
// E outros v�deos e exemplos descritos pelo c�digo...

using WebAPIMinimo.Startup;

// ATEN��O: TODO C�DIGO EST� DENTRO DO ARQUIVO "STARTUP.CS", pois estou inicializando com este arquivo.

WebApplicationBuilder? _ = WebApplication.CreateBuilder(args).UseStartup<Startup>();
