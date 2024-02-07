from abc import ABC, abstractmethod


class IFileLister(ABC):

    @abstractmethod
    def list_files(self, directory: str):
        pass

