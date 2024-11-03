Feature: Filter

As a text filter user
I want to filter text
So that I can see only the text that I am interested in

Scenario: Apply all filers
	Given I want to filter text
	When I apply the filters
	Then I see only the filtered text below
	"""
	  beginning            , and     : once  
she         reading,         , 'and   
use   ,'   '   ?' she  considering   own  ( 
  she ,          and ),        
         and picking  daisies,        
    .     remarkable  ;            
        , ' !  !    !' ( she    , 
     she      ,      all   );  
          , and   , and  hurried ,  
   ,   flashed     she  never         ,
        , and burning  , she      , and    
        large   under  hedge.       , never
  once considering    world  she     .        
   , and  dipped  ,            
herself  she  herself falling     .     ,  she   ,
  she      she       and  wonder     happen .
, she     and    she   ,        ;  she
    sides   , and     filled   and  shelves;  and 
she   and    . She      one   shelves  she passed;  
  ` ',        : she       
    killing ,       one     she   .
	"""
