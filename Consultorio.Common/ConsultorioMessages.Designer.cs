﻿//------------------------------------------------------------------------------
// <auto-generated>
//     O código foi gerado por uma ferramenta.
//     Versão de Tempo de Execução:4.0.30319.42000
//
//     As alterações ao arquivo poderão causar comportamento incorreto e serão perdidas se
//     o código for gerado novamente.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Consultorio.Common {
    using System;
    
    
    /// <summary>
    ///   Uma classe de recurso de tipo de alta segurança, para pesquisar cadeias de caracteres localizadas etc.
    /// </summary>
    // Essa classe foi gerada automaticamente pela classe StronglyTypedResourceBuilder
    // através de uma ferramenta como ResGen ou Visual Studio.
    // Para adicionar ou remover um associado, edite o arquivo .ResX e execute ResGen novamente
    // com a opção /str, ou recrie o projeto do VS.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "4.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    public class ConsultorioMessages {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal ConsultorioMessages() {
        }
        
        /// <summary>
        ///   Retorna a instância de ResourceManager armazenada em cache usada por essa classe.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        public static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("Consultorio.Common.ConsultorioMessages", typeof(ConsultorioMessages).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        /// <summary>
        ///   Substitui a propriedade CurrentUICulture do thread atual para todas as
        ///   pesquisas de recursos que usam essa classe de recurso de tipo de alta segurança.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        public static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///   Consulta uma cadeia de caracteres localizada semelhante a O campo Ativo é obrigatório.
        /// </summary>
        public static string AtivoInvalido {
            get {
                return ResourceManager.GetString("AtivoInvalido", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Consulta uma cadeia de caracteres localizada semelhante a Email inválido.
        /// </summary>
        public static string EmailInvalido {
            get {
                return ResourceManager.GetString("EmailInvalido", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Consulta uma cadeia de caracteres localizada semelhante a O nome da Empresa deve conter até 200 caracteres.
        /// </summary>
        public static string NomeEmpresaInvalido {
            get {
                return ResourceManager.GetString("NomeEmpresaInvalido", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Consulta uma cadeia de caracteres localizada semelhante a Nome da Empresa é obrigatório.
        /// </summary>
        public static string NomeEmpresaObrigatorio {
            get {
                return ResourceManager.GetString("NomeEmpresaObrigatorio", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Consulta uma cadeia de caracteres localizada semelhante a Nome do usuário é obrigatório.
        /// </summary>
        public static string NomeUsuarioObrigatorio {
            get {
                return ResourceManager.GetString("NomeUsuarioObrigatorio", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Consulta uma cadeia de caracteres localizada semelhante a Nome do usuário deve conter até 250 caracteres.
        /// </summary>
        public static string NomeUsuarioTamanho {
            get {
                return ResourceManager.GetString("NomeUsuarioTamanho", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Consulta uma cadeia de caracteres localizada semelhante a Confirmação de Senha inválida.
        /// </summary>
        public static string SenhaConfirmacaoInvalida {
            get {
                return ResourceManager.GetString("SenhaConfirmacaoInvalida", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Consulta uma cadeia de caracteres localizada semelhante a Senhas devem ser iguais.
        /// </summary>
        public static string SenhaIguaisInvalido {
            get {
                return ResourceManager.GetString("SenhaIguaisInvalido", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Consulta uma cadeia de caracteres localizada semelhante a Senha inválida.
        /// </summary>
        public static string SenhaInvalida {
            get {
                return ResourceManager.GetString("SenhaInvalida", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Consulta uma cadeia de caracteres localizada semelhante a Senha deve ter entre 6 e 20 caracteres.
        /// </summary>
        public static string SenhaTamanhoInvalida {
            get {
                return ResourceManager.GetString("SenhaTamanhoInvalida", resourceCulture);
            }
        }
    }
}
