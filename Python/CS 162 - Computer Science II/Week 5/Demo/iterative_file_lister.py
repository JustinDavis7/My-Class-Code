from ifilelister import IFileLister
import os


class IterativeFileLister(IFileLister):

    def list_files(self, directory: str):
        for subdir, dirs, files in os.walk(directory):
            for filename in files:
                abspath = subdir + os.sep + filename
                print(abspath)