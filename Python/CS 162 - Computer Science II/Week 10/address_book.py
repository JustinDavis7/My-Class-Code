import csv
from professional_contact import ProfessionalContact
from personal_class import PersonalContact


class AddressBook:
    def __init__(self, filename):
        self._contacts = []
        self._filename = filename
        self._load_data()

    def _load_data(self):
        self._contacts.clear()
        with open(self._filename) as file:
            for item in csv.reader(file, delimiter=',', skipinitialspace=True):
                if item[4] == '0':
                    self._contacts.append(ProfessionalContact(item[0], item[1], item[2], item[3], item[4], item[5]))
                else:
                    self._contacts.append(PersonalContact(item[0], item[1], item[2], item[3], item[4], item[5]))

    def save_address_book(self):
        with open(self._filename, 'w') as file:
            for contact in self._contacts:
                file.write(f'{contact.get_first_name()}, {contact.get_last_name()}, {contact.get_phone()}, {contact.get_email()}, {contact.get_type()}, {contact.get_sm_handle()}\n')

    def add_contact(self, contact):
        self._contacts.append(contact)
        self.save_address_book()

    def remove_contact(self, contact):
        found = False
        for i in range(len(self._contacts)):
            if self._contacts[i].get_phone == contact.get_phone():
                del self._contacts[i]
                found = True
                self.save_address_book()
                break

        if not found:
            raise Exception('Contact not found')

    def find_contact_by_phone(self, phone):
        for contact in self._contacts:
            contacts_phone = contact.get_phone()
            if contacts_phone == phone:
                return contact

        raise Exception('Contact not found')

    def print_contacts(self):
        for i, contact in enumerate(self._contacts):
            print(i, contact)
