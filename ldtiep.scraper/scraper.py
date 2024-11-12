import json
import sqlite3
import sys, requests
import time

from selenium.webdriver.chrome.service import Service as chrome_service
from selenium.webdriver.chrome.options import Options as chrome_options
from webdriver_manager.chrome import ChromeDriverManager
from selenium import webdriver
import concurrent.futures

def initDriver(IS_HEADLESS=False) -> webdriver:
    options = chrome_options()
    options.add_experimental_option(
        "excludeSwitches", ["enable-automation"])
    options.add_experimental_option('useAutomationExtension', False)
    options.add_argument("--disable-blink-features")
    options.add_argument("--disable-blink-features=AutomationControlled")
    options.add_argument('--headless')
    options.headless = True
    prefs = {
        "profile.managed_default_content_settings.images": 2
    }
    
    options.add_experimental_option("prefs", prefs)
    return webdriver.Chrome(service=chrome_service(
        ChromeDriverManager().install()), options=options)

driver = initDriver()

if __name__ == '__main__':

    driver.get("https://yody.vn/category/nam")
    input()
    # with concurrent.futures.ThreadPoolExecutor() as executor:
    #     # Submit tasks to the executor
    #     futures = [executor.submit(task, task_id) for task_id in task_ids]

    #     # Wait for all tasks to complete
    #     concurrent.futures.wait(futures)
