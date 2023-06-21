using System.ComponentModel.DataAnnotations.Schema;

namespace icts_test.Entities.Entities
{
    public class Notifies
    {
    public Notifies()
    {
        Notifycoes = new List<Notifies>();
    }
        [NotMapped]
        public string PropertyName { get; set; }
        [NotMapped]
        public string Message { get; set; }
        [NotMapped]
        public List<Notifies> Notifycoes { get; set; }

        public bool ValidadePropertyString(string value, string propertyName)
        {
            if (string.IsNullOrWhiteSpace(value) || string.IsNullOrWhiteSpace(propertyName)) 
            {
                Notifycoes.Add(new Notifies {
                    Message = "Campo Obrigatório",
                    PropertyName = propertyName
                });

                return false;
            }

            return true;
        }

        public bool ValidarPropriedadeInt(int value, string propertyName)
        {
            if (value < 1 || string.IsNullOrWhiteSpace(propertyName)) 
            {
                Notifycoes.Add(new Notifies {
                    Message = "Campo Obrigatório",
                    PropertyName = propertyName
                });

                return false;
            }

            return true;
        }
    }
}
