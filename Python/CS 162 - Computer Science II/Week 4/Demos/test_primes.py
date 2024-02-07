import unittest
from primes import Primes

class TestPrimes(unittest.TestCase):
    def setUp(self):
        self.primes = Primes()
        
    def test_five_is_prime(self):
        self.assertTrue(self.primes.is_prime(5))
        
    def test_four_is_not_prime(self):
        self.assertFalse(self.primes.is_prime(4))
