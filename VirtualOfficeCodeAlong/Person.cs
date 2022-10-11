
namespace VirtualOfficeCodeAlong; //sätt semikolon efter namespacet så försvinner dess måsvingar och det blir lite mer lättläst

public class Person
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string FullName 
    { 
        get 
        { 
            return $"{FirstName} {LastName}"; 
        } 
    } 
    public int Age { get; set; }

    //skapa en default-bio
    public virtual string ShowBio()
    {
        return "No bio has been added yet!";
    }
}
