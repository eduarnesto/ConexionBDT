namespace ENT
{
    public class ClsPersona
    {
        #region Propiedades
        public int id { get; set; }
        public string nombre { get; set; }
        public string apellidos { get; set; }
        public string telefono { get; set; }
        public string direccion { get; set; }
        public string foto { get; set; }
        public DateTime fechaNacimiento { get; set; }
        public int idDepartamento { get; set; }
        #endregion


        #region constructores
        public ClsPersona() { }

        public ClsPersona(int id, string nombre, string apellidos, string telefono, string direccion, string foto, DateTime fechaNacimiento, int idDepartamento)
        {
            this.id = id;
            this.nombre = nombre;
            this.apellidos = apellidos;
            this.telefono = telefono;
            this.direccion = direccion;
            this.foto = foto;
            this.fechaNacimiento = fechaNacimiento;
            this.idDepartamento = idDepartamento;
        }
        #endregion
    }
}
