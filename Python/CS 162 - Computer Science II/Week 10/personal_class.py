from contact import Contact


class PersonalContact(Contact):
    def __init__(self, first_name, last_name, phone, email, contact_type, facebook_handle):
        super().__init__(first_name, last_name, phone, email, contact_type, facebook_handle)

    def contact_via_social_media(self, message):
        print(f'Posting to Facebook using handle: {self._facebook_handle} {message}')
