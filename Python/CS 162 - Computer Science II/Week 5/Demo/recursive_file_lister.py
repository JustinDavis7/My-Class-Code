from ifilelister import IFileLister
import os


class RecursiveFileLister(IFileLister):
    def list_files(self, directory: str):
        files = os.listdir(directory)
        for file in files:
            absolute_path = os.path.join(directory, file)
            if os.path.isdir(absolute_path):
                self.list_files(absolute_path)
            else:
                print(absolute_path)