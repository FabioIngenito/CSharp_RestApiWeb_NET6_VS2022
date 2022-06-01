// Baseado e bastante modificado do Exemplo:
//
// MINIMAL APIs COM SQL ( .NET6 C# ) VISUAL STUDIO 2022
// 11 de nov. de 2021 - Tempo de vídeo: 34:01
// DEV NET CORE Valdir Ferreira
// https://youtu.be/_vzTewWNI4k
//
// E outros vídeos e exemplos descritos pelo código...

using WebAPIMinimo.Startup;

// ATENÇÃO: TODO CÓDIGO ESTÁ DENTRO DO ARQUIVO "STARTUP.CS", pois estou inicializando com este arquivo.

WebApplicationBuilder? _ = WebApplication.CreateBuilder(args).UseStartup<Startup>();
