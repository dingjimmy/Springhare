Feature: Sessions

- A Session represents a period of time that an agent is ready to do work.
  notready -> ready -> done
- An Action represents a period of time when an agent is activly doing work.
  Many actions can be performed during the lifetime of a session, but a 
  session can only perform one action concurrently.

Scenario: Begin a session
    Given a command is sent to to begin a new session
    When the session has successfully initialised
    Then a response is sent that the session is ready

Scenario: Failed to begin a session
    Given a command is sent to to begin a new session
    When the session has failed to initialise
    Then a response is sent that the session is notready

Scenario: End a session
    Given a command is sent to end a session
    When the session has successfully ended
    Then a response is sent that the session is done

Scenario: Retrieve current status of a session
    When a command is sent to retrieve status of a session
    Then a response is sent with status of the session

Scenario: Execute an action during a session
    Given a command is sent to execute an action 
    When the action successfully starts executing
    Then a response is sent that the action is executing

Scenario: Execute more than one action concurrently
    Given an action is currently executing
    When a command is sent to execute another action 
    Then a response is sent that the second action failed


Scenario: Retrieve current status of an action
    When a command is sent to retrieve status of an action
    Then a response is sent with status of the action

Scenario: Retrieve data aquired or generated from a session action
    Given 
    When 
    Then 