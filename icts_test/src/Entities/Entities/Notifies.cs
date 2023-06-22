using System.ComponentModel.DataAnnotations.Schema;

namespace icts_test.Entities.Entities
{
    public class Notifies
    {
        public Notifies()
        {
            Notitycoes = new List<Notifies>();
        }
        [NotMapped]
        public string PropertyName { get; set; }
        [NotMapped]
        public string Message { get; set; }
        [NotMapped]
        public List<Notifies> Notitycoes { get; set; }

        public bool ValidatePropertyString(string value, string propertyName)
        {
            if (string.IsNullOrWhiteSpace(value) || string.IsNullOrWhiteSpace(propertyName))
            {
                Notitycoes.Add(new Notifies
                {
                    Message = "Campo Obrigatório",
                    PropertyName = propertyName
                });

                return false;
            }

            return true;
        }

        public bool ValidatePropertyInt(int value, string propertyName)
        {
            if (value < 1 || string.IsNullOrWhiteSpace(propertyName))
            {
                Notitycoes.Add(new Notifies
                {
                    Message = "Campo Obrigatório",
                    PropertyName = propertyName
                });

                return false;
            }

            return true;
        }
    }
}
