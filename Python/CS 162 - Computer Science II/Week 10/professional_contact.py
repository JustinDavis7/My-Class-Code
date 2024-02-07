from contact import Contact


class ProfessionalContact(Contact):
    def __init__(self, first_name, last_name, phone, email, contact_type, linked_in_handle):
        super().__init__(first_name, last_name, phone, email, contact_type, linked_in_handle)

    def contact_via_social_media(self, message):
        print(f'Posting to LinkedIn using handle: {self.get_sm_handle()} {message}')