//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace AirSystem.Database
{
    using System;
    using System.Collections.Generic;
    
    public partial class Usuarios
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Usuarios()
        {
            this.Acesso = new HashSet<Acesso>();
        }
    
        public int IdUsuario { get; set; }
        public string Tx_Nome { get; set; }
        public string Tx_Sobrenome { get; set; }
        public string Tx_Logradouro { get; set; }
        public string Nr_Casa { get; set; }
        public System.DateTime Dt_Nascimento { get; set; }
        public string Tx_Usuario { get; set; }
        public string Tx_Senha { get; set; }
        public string Tx_CaminhoFoto { get; set; }
        public bool IsAdmin { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Acesso> Acesso { get; set; }
    }
}
