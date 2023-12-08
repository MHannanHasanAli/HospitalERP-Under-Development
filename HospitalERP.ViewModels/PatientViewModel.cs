using HospitalERP.Entities;

namespace HospitalERP.ViewModels
{
    public class PatientViewModel
    {

    }

    public class PatientListingViewModel
    {

        public PatientListingViewModel()
        {
            Patients = new List<User>();
        }

        public List<User> Patients { get; set; }
    }
}

