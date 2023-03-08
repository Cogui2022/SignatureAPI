using AppSignature.Aplicaciones.Servicios;
using AppSignature.Dominio;
using AppSignature.Dominio.Interfaces.Repositorio;
using AppSignature.Infraestructura.Datos.Contextos;
using AppSignature.Infraestructura.Datos.Repositorios;

namespace AppSignature.Aplicaciones.Test
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void ValidacionServicioTest()
        {
            RolContexto db = new RolContexto();
            RolRepositorio repo = new RolRepositorio(db);
            ValidacionServicio servicio = new ValidacionServicio(repo);

            var ContractsList = new List<Contract>
            {
                new Contract
                {
                    contractId=new Guid(),
                    contractName="contract1",
                    signature=new List<Rol>
                    {
                        new Rol
                        {
                             rolId= new Guid(),
                                name= "N",
                                points= 0
                        }
                        ,new Rol
                        {
                            rolId= new Guid(),
                                name= "N",
                                points= 0
                        },
                        new Rol
                        {
                            rolId= new Guid(),
                                name= "V",
                                points= 0
                        }
                    }
                },
                new Contract
                {
                    contractId=new Guid(),
                    contractName="contract2",
                    signature=new List<Rol>
                    {
                        new Rol
                        {
                             rolId= new Guid(),
                                name= "K",
                                points= 0
                        }
                        ,new Rol
                        {
                            rolId= new Guid(),
                                name= "N",
                                points= 0
                        },
                        new Rol
                        {
                            rolId= new Guid(),
                                name= "V",
                                points= 0
                        }
                    }
                }
            };

            var result = servicio.Validar(ContractsList);
            Assert.IsNotNull(result);
        }

        [Test]
        public void GenerateWinSignatureServicioTest()
        {
            RolContexto db = new RolContexto();
            RolRepositorio repo = new RolRepositorio(db);
            GenerateWinSignatureServicio servicio = new GenerateWinSignatureServicio(repo);

            var ContractsList = new List<Contract>
            {
                new Contract
                {
                    contractId=new Guid(),
                    contractName="contract1",
                    signature=new List<Rol>
                    {
                        new Rol
                        {
                             rolId= new Guid(),
                                name= "N",
                                points= 0
                        }
                        ,new Rol
                        {
                            rolId= new Guid(),
                                name= "#",
                                points= 0
                        },
                        new Rol
                        {
                            rolId= new Guid(),
                                name= "V",
                                points= 0
                        }
                    }
                },
                new Contract
                {
                    contractId=new Guid(),
                    contractName="contract2",
                    signature=new List<Rol>
                    {
                        new Rol
                        {
                             rolId= new Guid(),
                                name= "N",
                                points= 0
                        }
                        ,new Rol
                        {
                            rolId= new Guid(),
                                name= "V",
                                points= 0
                        },
                        new Rol
                        {
                            rolId= new Guid(),
                                name= "V",
                                points= 0
                        }
                    }
                }
            };

            var result = servicio.GenerateWinSignature(ContractsList);
            Assert.IsNotNull(result);
        }
    }
}