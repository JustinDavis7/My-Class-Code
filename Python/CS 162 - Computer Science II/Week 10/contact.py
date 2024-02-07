from abc import ABC, abstractmethod


class Contact(ABC):
    PROFESSIONAL = 0
    PERSONAL = 1

    def __init__(self, first_name, last_name, phone, email, contact_type, sm_handle):
        self._first_name = first_name
        self._last_name = last_name
        self._phone = phone
        self._email = email
        self._sm_handle = sm_handle
        self._contact_type = contact_type

    def change_first_name(self, new_first_name):
        self._first_name = new_first_name

    def change_last_name(self, new_last_name):
        self._last_name = new_last_name

    def change_phone(self, new_phone):
        self._phone = new_phone

    def change_email(self, new_email):
        self._email = new_email

    def get_first_name(self):
        return self._first_name

    def get_last_name(self):
        return self._last_name

    def get_phone(self):
        return self._phone

    def get_email(self):
        return self._email

    def get_sm_handle(self):
        return self._sm_handle

    def get_type(self):
        return self._contact_type

    def __eq__(self, other):
        return self._first_name == other.get_first_name() and self._last_name == other.get_last_name() and self._phone == other.get_phone and \
            self._email == other.get_email() and self._contact_type == other.get_contact_type() and self._sm_handle == other.get_sm_handle

    def __str__(self):
        return f'{self._first_name}, {self._last_name}, {self._phone}, {self._email}, {self._contact_type}, {self._sm_handle}'

    @abstractmethod
    def contact_via_social_media(self, message):
        pass
