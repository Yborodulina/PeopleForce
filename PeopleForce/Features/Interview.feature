@interview
Feature: Interview

    Scenario: Get list of interview
        Given user filter interview from "2023-2-1" to "2023-2-28"
        Given user save interviews data to the "interviews"
        Then user write data "interviews" to the google sheet "1tJGo2-l07mPlGLd3Tu7WhimUViJ4tFF8Q_jmiFOAZ3Q"