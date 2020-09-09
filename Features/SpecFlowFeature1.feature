Feature: SpecFlowFeature1
	

@mytag
Scenario: create the single user 
	Given name of user = morpheus
	And job = leader
	When I create user 
	Then validate user is created