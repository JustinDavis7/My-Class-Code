from contact import Contact
from professional_contact import ProfessionalContact
from personal_class import PersonalContact
from address_book import AddressBook


def get_input(message):
    response = input(message + '\n-->')
    return response

def main():
    address_book = AddressBook('contacts.csv')

    menu = '\n1. Display contacts\n2. Add contact\n3. Remove contact\n4. Find contact\n5. Save\n6. Quit'

    choice = get_input(menu)

    while choice != '6':
        if choice == '1':
            address_book.print_contacts()

        elif choice == '2':
            first_name = get_input('Enter first name: ')
            last_name = get_input('Enter last name: ')
            email = get_input('Enter email: ')
            phone = get_input('Enter phone: ')
            type = get_input('Enter contact type, (1) Professional (2) Personal: ')
            sm_handle = get_input('Enter social media handle: ')
            if type == Contact.PROFESSIONAL:
                contact = ProfessionalContact(first_name, last_name, phone, email, Contact.PROFESSIONAL, sm_handle)
            else:
                contact = PersonalContact(first_name, last_name, phone, email, Contact.PERSONAL, sm_handle)

            address_book.add_contact(contact)

        elif choice == '3':
            phone = get_input('Enter contacts phone number: ')
            try:
                contact = address_book.find_contact_by_phone(phone)
                address_book.remove_contact(contact)
            except Exception as exception:
                print(f'Contact with {phone} not found. Try again.')

        elif choice == '4':
            phone = get_input('Enter contacts phone number: ')
            try:
                contact = address_book.find_contact_by_phone(phone)
                print(contact)
            except Exception as exception:
                print(f'Contact with {phone} not found. Try again.')

        elif choice == '5':
            address_book.save_address_book()

        else:
            print('Invalid option')

        choice = get_input(menu)

    address_book.save_address_book()

    print('Closing the address book. Goodbye.')


if __name__ == '__main__':
    main()
