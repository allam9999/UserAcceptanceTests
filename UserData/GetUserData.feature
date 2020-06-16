Feature: GetUserData

Scenario: Verify Get User Data Api
   Given I have a userId of 15
   When I make a call to the GetUser Api
   Then I should receive a status code of OK from the api
   And  I should get the following user data
     | first_name | last_name | email                 | ip_address     | latitude  | longitude  | city |
     | Roanne     | Copland   | rcoplande@example.com | 25.253.221.139 | 29.560254 | 106.454213 | Caqu |

Scenario: Verify Get User Data by City Api
   Given I have a city Kax
   When I make a call to the GetUsersByCity Api
   Then I should receive a status code of OK from the api
   And  I should get the following data
     | first_name | last_name | email                  | ip_address     | latitude  | longitude    |
     | Maurise    | Shieldon  | mshieldon0@squidoo.com | 192.57.232.111 | 34.003135 | -117.7228641 |
     | Nelly      | Thurley   | nthurleynp@joomla.org  | 46.72.120.66   | 34.003135 | -117.7228641 | 

Scenario: Verify Get all user Data Api
   When I make a call to the GetAllUserData Api
   Then I should receive a status code of OK from the api
   And the total user count should be 1000	