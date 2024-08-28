using DataAnnotationsExample.Models;

namespace DataAnnotationsExample.Validators;

public class PersonValidator
{
    private const int _realMinValueAge = 6;

    public Dictionary<string, string> Validate(Person person)
    {
        var validationDict = new Dictionary<string, string>();

        if (string.IsNullOrEmpty(person.FirstName) && string.IsNullOrEmpty(person.LastName))
        {
            validationDict.Add("PersonRule", "Ce n'est logique !!");
        }

        if (person.Age == _realMinValueAge)
        {
            validationDict.Add("AgePersonRule", "Trop petit !!");
        }

        return validationDict;
    }
}
