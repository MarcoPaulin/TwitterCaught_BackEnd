import json
import sys
from apify_client import ApifyClient

def getTweets(name, nbTweets):
    # Initialize the ApifyClient with your API token
    client = ApifyClient("apify_api_rdf7bW40eUBfaHDERHf2sVyMOpGWmX0wuUsP")

    # Prepare the actor input
    run_input = {
        "startUrls": [{ "url": "https://twitter.com/"+name }],
        "tweetsDesired": nbTweets,
    }

    # Run the actor and wait for it to finish
    run = client.actor("quacker/twitter-url-scraper").call(run_input=run_input)
    data = []
    # Fetch and print actor results from the run's dataset (if there are any)
    for item in client.dataset(run["defaultDatasetId"]).iterate_items():
        data.append(item['full_text'])

    with open("tweets.json", "w") as f: 
        data = json.dump(data, f)

if __name__ == "__main__":
  print("test")
  args = sys.argv
  print(args[1] + " " + args[2])
  getTweets(args[1],  int(args[2]))