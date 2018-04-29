from locust import HttpLocust, TaskSet, task
import resource
import random

resource.setrlimit(resource.RLIMIT_NOFILE, (999999, 999999))

# run with sudo locust --host=http://{{hostname}}
class UserBehavior(TaskSet):

    def get_random_query(self):
        base = "Search?"
        nameString="nameString="
        random_number = random.randint(100,600)
        combined_query = base + nameString + str(random_number)
        return combined_query

    @task(1)
    def load_page(self):
        self.client.get("/" + self.get_random_query())

class WebsiteUser(HttpLocust):
    task_set = UserBehavior
    min_wait = 5000
    max_wait = 9000


