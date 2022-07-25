Feature: Open webapp

As a test developer
I want to be able to write a specflow test
So that I can check that the web app does launch properly

    @webapp
    Scenario: Webapp launches successfully
        Given I launch the web app url
        Then web app should have launched properly
        
    @webapp
    Scenario: WebAPI launches successfully
        Given I add the "https://api.publicapis.org" URL with endpoint "entries"
        When I execute the request
        Then the correct "OK" response is returned 